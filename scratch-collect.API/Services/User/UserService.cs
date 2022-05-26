using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scratch_collect.API.Database;
using scratch_collect.API.Exceptions;
using scratch_collect.API.Helper;
using scratch_collect.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using User = scratch_collect.Model.User.User;

namespace scratch_collect.API.Services
{
    public class UserService : IUserService
    {
        private readonly ScratchCollectContext _context;
        private readonly IMapper _mapper;

        public UserService(ScratchCollectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<User> Get(UserSearchRequest request)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Email))
            {
                query = query.Where(x => x.Email.StartsWith(request.Email));
            }

            if (!string.IsNullOrWhiteSpace(request?.Username))
            {
                query = query.Where(x => x.Username.StartsWith(request.Username));
            }

            var list = query.Include(x => x.UserRoles).ToList();

            return _mapper.Map<List<User>>(list);
        }

        public User GetById(int id)
        {
            var entity = _context.Users
                .Include(x => x.UserRoles)
                .SingleOrDefault(x => x.Id == id);

            return _mapper.Map<User>(entity);
        }

        public User Insert(UserUpsertRequest request)
        {
            var entity = _mapper.Map<Database.User>(request);

            // check if user already exist ?
            var userAlreadyExist = _context.Users.Any(x => x.Email == request.Email);

            if (userAlreadyExist)
                throw new BadRequestException("User with provided email already exist in the system !");

            entity.PasswordSalt = Password.GenerateSalt();
            entity.PasswordHash = Password.GenerateHash(entity.PasswordSalt, request.Password);

            _context.Users.Add(entity);
            _context.SaveChanges();

            foreach (var userRole in request.Roles.Select(role => new Database.UserRole
            {
                UserId = entity.Id,
                RoleId = role,
                UpdatedAt = DateTime.Now
            }))
            {
                _context.UserRoles.Add(userRole);
            }

            _context.SaveChanges();
            return _mapper.Map<User>(entity);
        }

        [Authorize("Administrator")]
        [HttpPut]
        public User Update(int id, UserUpsertRequest request)
        {
            var entity = _context.Users.Find(id);

            if (entity == null)
                throw new BadRequestException("User does not exist !");

            var emailEntity = _context.Users.FirstOrDefault(x => x.Email == request.Email);

            // if there is another user in the system with email value passed in request
            if (emailEntity != null && entity.Email != emailEntity.Email)
                throw new BadRequestException("There is another user with provided email address !");

            _context.Users.Attach(entity);
            _context.Users.Update(entity);
            _mapper.Map(request, entity);

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                entity.PasswordSalt = Password.GenerateSalt();
                entity.PasswordHash = Password.GenerateHash(entity.PasswordSalt, request.Password);
            }

            _context.SaveChanges();

            var userRoles = _context.UserRoles.Where(x => x.UserId == entity.Id);

            if (request.Roles.Count <= userRoles.Count())
            {
                foreach (var role in userRoles)
                {
                    if (!request.Roles.Contains(role.RoleId))
                    {
                        _context.UserRoles.Remove(role);
                    }
                }
            }

            if (request.Roles != null && request.Roles.Any() && request.Roles[0] != 0)
            {
                foreach (var role in request.Roles
                    .Where(role => !_context.UserRoles
                        .Any(x => x.UserId == entity.Id && x.RoleId == role)))
                {
                    _context.UserRoles.Add(new UserRole()
                    {
                        RoleId = role,
                        UserId = entity.Id,
                        UpdatedAt = DateTime.Now
                    });
                }
            }

            _context.SaveChanges();
            return _mapper.Map<User>(entity);
        }
    }
}