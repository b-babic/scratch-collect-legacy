using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using scratch_collect.API.Database;
using scratch_collect.API.Exceptions;
using scratch_collect.API.Helper;
using scratch_collect.Model.Auth;
using scratch_collect.Model.Enums;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using User = scratch_collect.Model.User.User;

namespace scratch_collect.API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ScratchCollectContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public AuthenticationService(IMapper mapper, ScratchCollectContext context, IOptions<AppSettings> appSettings)
        {
            _mapper = mapper;
            _context = context;
            _appSettings = appSettings.Value;
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

        public SignedUser Signin(SigninRequest request)
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
                throw new BadRequestException("User does not exist!");

            // check password
            var requestHash = Password.GenerateHash(user.PasswordSalt, request.Password);
            if (user.PasswordHash != requestHash)
                throw new BadRequestException("Wrong password!");

            // authentication successful so generate jwt token
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var customClaims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
            };

            customClaims.AddRange(user.UserRoles.Select(role => new Claim(ClaimTypes.Role, role.Role.Name)));

            var token = new JwtSecurityToken
            (issuer: null,
                audience: null,
                claims: customClaims,
                notBefore: DateTime.Now,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: credentials
            );

            user.Token = new JwtSecurityTokenHandler().WriteToken(token);

            return _mapper.Map<SignedUser>(user);
        }
    }
}