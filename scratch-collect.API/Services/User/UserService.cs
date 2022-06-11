using AutoMapper;
using Microsoft.EntityFrameworkCore;
using scratch_collect.API.Database;
using scratch_collect.API.Exceptions;
using scratch_collect.API.Helper;
using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System.Collections.Generic;
using System.Linq;

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

        public List<UserDTO> Get(UserSearchRequest request)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Email))
            {
                query = query.Where(x => x.Email.StartsWith(request.Email));
                var test = _mapper.Map<List<User>>(query.ToList());
            }

            if (!string.IsNullOrWhiteSpace(request?.Username))
            {
                query = query.Where(x => x.Username.StartsWith(request.Username));
            }

            var list = query.Include(x => x.Role).ToList();

            return _mapper.Map<List<UserDTO>>(list);
        }

        public UserDTO GetById(int id)
        {
            var entity = _context.Users
                .Include(x => x.Role)
                .SingleOrDefault(x => x.Id == id);

            return _mapper.Map<UserDTO>(entity);
        }

        public UserDTO Insert(UserUpsertRequest request)
        {
            var entity = _mapper.Map<User>(request);

            // check if user already exist ?
            var userAlreadyExist = _context.Users.Any(x => x.Email == request.Email);

            if (userAlreadyExist)
                throw new BadRequestException("User with provided email already exist in the system !");

            entity.PasswordSalt = Password.GenerateSalt();
            entity.PasswordHash = Password.GenerateHash(entity.PasswordSalt, request.Password);

            _context.Users.Add(entity);
            _context.SaveChanges();

            _context.SaveChanges();

            var result = _context.Users.Include(a => a.Role).FirstOrDefault(x => x.Id == entity.Id);

            return _mapper.Map<UserDTO>(result);
        }

        //TODO: Edit profile (client)
        //[HttpPut]
        //public UserDTO Update(int id, ProfileUpsertReuqest request)
        //{
        //    var entity = _context.Users.Find(id);

        //    if (entity == null)
        //        throw new BadRequestException("User does not exist !");

        //    var emailEntity = _context.Users.FirstOrDefault(x => x.Email == request.Email);

        //    // if there is another user in the system with email value passed in request
        //    if (emailEntity != null && entity.Email != emailEntity.Email)
        //        throw new BadRequestException("There is another user with provided email address !");

        //    _context.Users.Attach(entity);
        //    _context.Users.Update(entity);
        //    _mapper.Map(request, entity);

        //    if (!string.IsNullOrWhiteSpace(request.Password))
        //    {
        //        entity.PasswordSalt = Password.GenerateSalt();
        //        entity.PasswordHash = Password.GenerateHash(entity.PasswordSalt, request.Password);
        //    }

        //    _context.SaveChanges();

        //    _context.SaveChanges();
        //    return _mapper.Map<UserDTO>(entity);
        //}

        public UserDTO Update(int id, UserUpsertRequest request)
        {
            var entity = _context.Users.Find(id);

            if (entity == null)
                throw new BadRequestException("User does not exist !");

            _context.Users.Attach(entity);
            _context.Users.Update(entity);
            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<UserDTO>(entity);
        }

        public void Delete(int id)
        {
            var entity = _context.Users.Find(id);

            if (entity == null)
            {
                throw new BadRequestException("There is no user with provided email address !");
            }

            // Cascade Relations
            // This essentially resets used coupons so we can use them again.
            // For demo purposes only and not suitable for production use hence it makes not much sense.
            var userCoupons = _context.Coupons.Where(c => c.UsedById == entity.Id).ToList();

            if (userCoupons.Count() > 0)
            {
                foreach (var coupon in userCoupons)
                {
                    _context.Coupons.Remove(coupon);
                }
            }

            _context.Users.Remove(entity);
            _context.SaveChanges();
        }
    }
}