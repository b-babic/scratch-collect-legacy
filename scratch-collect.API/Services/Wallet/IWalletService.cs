using scratch_collect.Model;

namespace scratch_collect.API.Services
{
    public interface IWalletService
    {
        public void Delete(int id);

        public WalletDTO AddBalance(int id, double amount);

        public WalletDTO RemoveBalance(int id, double amount);
    }
}