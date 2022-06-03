using scratch_collect.Model.User.Desktop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.Desktop.Services
{
    public interface IUserService
    {
        public Task<List<UserVM>> GetAllUsers(string emailQuery = null, string usernameQuery = null);
    }
}