using AutoMapper;
using Microsoft.EntityFrameworkCore;
using scratch_collect.API.Database;
using scratch_collect.API.Exceptions;
using scratch_collect.API.Helper;
using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System;
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

            var list = query
            .Include(x => x.Role)
            .Include(u => u.Wallet)
            .ToList();

            return _mapper.Map<List<UserDTO>>(list);
        }

        public UserDTO GetById(int id)
        {
            var entity = _context.Users
                .Include(x => x.Role)
                .Include(y => y.Wallet)
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

            if (request.RegisteredAt == null) entity.RegisteredAt = DateTime.Now;

            entity.PasswordSalt = Password.GenerateSalt();
            entity.PasswordHash = Password.GenerateHash(entity.PasswordSalt, request.Password);

            _context.Users.Add(entity);
            _context.SaveChanges();

            // Create new user wallet
            var wallet = new WalletUpsertRequest
            {
                Balance = 50,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = entity.Id
            };

            var walletModel = _mapper.Map<Wallet>(wallet);

            _context.Wallets.Add(walletModel);
            _context.SaveChanges();

            var result = _context
                .Users
                .Include(a => a.Role)
                .Include(w => w.Wallet)
                .FirstOrDefault(x => x.Id == entity.Id);

            return _mapper.Map<UserDTO>(result);
        }

        public UserDTO EditProfile(int id, EditProfileRequest request)
        {
            var entity = _context.Users.Find(id);

            if (entity == null)
                throw new BadRequestException("User does not exist !");

            if (request.Username != null)
                entity.Username = request.Username;

            if (request.Email != null)
                entity.Email = request.Email;

            if (request.FirstName != null)
                entity.FirstName = request.FirstName;

            if (request.LastName != null)
                entity.LastName = request.LastName;

            if (request.Address != null)
                entity.Address = request.Address;

            _context.Users.Attach(entity);
            _context.Users.Update(entity);

            _context.SaveChanges();

            return _mapper.Map<UserDTO>(entity);
        }

        public UserDTO EditPassword(int id, EditPasswordRequest request)
        {
            var entity = _context.Users.Find(id);

            if (entity == null)
                throw new BadRequestException("User does not exist !");

            var requestHash = Password.GenerateHash(entity.PasswordSalt, request.OldPassword);
            var newHash = Password.GenerateHash(entity.PasswordSalt, request.NewPassword);

            if (entity.PasswordHash != requestHash)
                throw new BadRequestException("Old password is wrong!");

            if (requestHash == newHash)
                throw new BadRequestException("Password cannot be same as old one!");

            entity.PasswordHash = newHash;

            _context.Users.Attach(entity);
            _context.Users.Update(entity);

            _context.SaveChanges();

            return _mapper.Map<UserDTO>(entity);
        }

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

        // Get used coupons
        public List<CouponDTO> GetUsersCoupons(int id)
        {
            var user = _context
                        .Users
                        .Include(a => a.Role)
                        .Include(a => a.UsedCoupons)
                        .SingleOrDefault(b => b.Id == id);

            if (user == null)
                throw new BadRequestException("No user found !");

            var coupons = user.UsedCoupons;

            return _mapper.Map<List<CouponDTO>>(coupons);
        }

        // Won items
        public List<UserOfferDTO> UserWonItems(UsserOfferSearchRequest request)
        {
            var query = _context
                .UserOffers
                .Include(a => a.Offer)
                .ThenInclude(b => b.Category)
                .ToList()
                .Where(x => x.UserId == request.UserId && x.Won == true)
                .AsQueryable();

            if (!String.IsNullOrEmpty(request.Query))
            {
                query = query.Where(x => x.Offer.Title.Contains(request.Query));
            }

            // Default order
            var list = query
                .OrderByDescending(a => a.PlayedOn)
                .AsEnumerable();

            return _mapper.Map<List<UserOfferDTO>>(list);
        }

        public List<UserOfferDTO> AllWonItems(UsserOfferSearchRequest request)
        {
            var query = _context
                .UserOffers
                .Include(a => a.Offer)
                .ThenInclude(b => b.Category)
                .Include(u => u.User)
                .Where(x => x.Won == true)
                .OrderByDescending(a => a.PlayedOn)
                .AsQueryable();

            if (!string.IsNullOrEmpty(request.TimeFrom) && string.IsNullOrEmpty(request.TimeTo))
            {
                DateTime from = DateTime.Parse(request.TimeFrom);

                query = query.Where(s => s.PlayedOn >= from);
            }
            else if (string.IsNullOrEmpty(request.TimeFrom) && !string.IsNullOrEmpty(request.TimeTo))
            {
                DateTime to = DateTime.Parse(request.TimeTo);

                query = query.Where(s => s.PlayedOn <= to);
            }
            else if (!string.IsNullOrEmpty(request.TimeFrom) && !string.IsNullOrEmpty(request.TimeTo))
            {
                DateTime from = DateTime.Parse(request.TimeFrom);
                DateTime to = DateTime.Parse(request.TimeTo);

                query = query.Where(s => s.PlayedOn >= from && s.PlayedOn <= to);
            }

            var list = query.ToList();

            if (list == null)
                throw new BadRequestException("No items found !");

            return _mapper.Map<List<UserOfferDTO>>(list);
        }
    }
}