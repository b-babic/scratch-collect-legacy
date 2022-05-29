using scratch_collect.Model.User;
using scratch_collect.Model.User.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scratch_collect.Desktop.Services
{
    public interface IUserService
    {
        public Task<List<UserVM>> GetAllUsers();
    }
}