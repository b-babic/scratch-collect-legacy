using AutoMapper;
using scratch_collect.API.Database;
using scratch_collect.API.Exceptions;
using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System;
using System.Linq;

namespace scratch_collect.API.Services
{
    public class WalletService : IWalletService
    {
        private readonly ScratchCollectContext _context;
        private readonly IMapper _mapper;

        public WalletService(ScratchCollectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public WalletDTO Insert(WalletUpsertRequest request)
        {
            var entity = _mapper.Map<Wallet>(request);

            // optional fields
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;

            // check if wallet already exist ?
            var walletExists = _context.Wallets.Any(x => x.UserId == request.UserId);

            if (walletExists)
                throw new BadRequestException("User already has wallet attached !");

            _context.Wallets.Add(entity);
            _context.SaveChanges();

            _context.SaveChanges();

            var result = _context.Wallets.Find(entity.Id);

            return _mapper.Map<WalletDTO>(result);
        }

        public WalletDTO AddBalance(int id, double amount)
        {
            var entity = _context.Wallets.Find(id);

            if (entity == null)
                throw new BadRequestException("Wallet does not exist !");

            entity.Balance += amount;

            _context.Wallets.Attach(entity);
            _context.Wallets.Update(entity);

            _context.SaveChanges();

            return _mapper.Map<WalletDTO>(entity);
        }

        public WalletDTO RemoveBalance(int id, double amount)
        {
            var entity = _context.Wallets.Find(id);

            if (entity == null)
                throw new BadRequestException("Wallet does not exist !");

            entity.Balance -= amount;

            _context.Wallets.Attach(entity);
            _context.Wallets.Update(entity);

            _context.SaveChanges();

            return _mapper.Map<WalletDTO>(entity);
        }

        public void Delete(int id)
        {
            var entity = _context.Wallets.Find(id);

            if (entity == null)
            {
                throw new BadRequestException("There is no wallet with provided id !");
            }

            _context.Wallets.Remove(entity);
            _context.SaveChanges();
        }
    }
}