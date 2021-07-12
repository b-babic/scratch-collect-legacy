using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scratch_collect.API.Database;
using scratch_collect.API.Exceptions;
using scratch_collect.API.Helper;
using scratch_collect.Model.Auth;
using scratch_collect.Model.Enums;
using User = scratch_collect.Model.User.User;

namespace scratch_collect.API.Services
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly ScratchCollectContext _context;
        private readonly IMapper _mapper;

        public AuthenticationService(IMapper mapper, ScratchCollectContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public User Signup(SignupRequest request)
        {
            var entity = _mapper.Map<Database.User>(request);
            
            // check if user is unique (already have an account ? )
            var accountAlreadyExist =
                _context.Users.Any(x => x.Username == request.Username || x.Email == request.Email);
            
            // check if account already exist
            if (accountAlreadyExist)
                throw new BadRequestException("Account with provided email | username already exist !");
                
            // check if passwords match
            if (request.Password != request.PasswordConfirm)
                throw new BadRequestException("Passwords did not match !");
            
            entity.PasswordSalt = Password.GenerateSalt();
            entity.PasswordHash = Password.GenerateHash(entity.PasswordSalt, request.Password);
            
            _context.Users.Add(entity);
            _context.SaveChanges();
            
            // Assign default user role when signin up
            var userRole = new UserRole()
            {
                UserId = entity.Id,
                RoleId = (int)Roles.Client,
                UpdatedAt = DateTime.Now
            };

            _context.UserRoles.Add(userRole);            
            _context.SaveChanges();

            return _mapper.Map<User>(entity);
        }

        public User HandleSignin(string email, string password)
        {
            var request = new SigninRequest()
            {
                Email = email,
                Password = password
            };

            return Signin(request);
        }
        
        public User Signin(SigninRequest request)
        {
            if (string.IsNullOrEmpty(request.Email))
                throw new ArgumentNullException(request.Email, "You must provide email !");

            if (string.IsNullOrEmpty(request.Password))
                throw new ArgumentNullException(request.Password, "You must provide password !");
            
            var user = _context.Users
                .Include(i => i.UserRoles)
                .ThenInclude(j => j.Role)
                .FirstOrDefault(x => x.Email == request.Email);

            if (user == null)
                throw new BadRequestException("Account with provided email do not exist !");
            
            var newHash = Password.GenerateHash(user.PasswordSalt, request.Password);
            
            if(newHash != user.PasswordHash)
                throw new BadRequestException("User does not match given password !");

            return _mapper.Map<User>(user);
        }
    }
}