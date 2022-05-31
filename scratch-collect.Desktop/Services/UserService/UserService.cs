using AutoMapper;
using scratch_collect.Model.User;
using scratch_collect.Model.User.Desktop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.Desktop.Services
{
    public class UserService : IUserService
    {
        private static string _baseUrl = System.Configuration.ConfigurationManager.AppSettings["BASE_API_URL"] + "user";
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<UserVM>> GetAllUsers(string emailQuery = null, string usernameQuery = null)
        {
            Dictionary<string, string> parameters = new();

            if (!string.IsNullOrEmpty(emailQuery))
                parameters["Email"] = emailQuery;

            if (!string.IsNullOrEmpty(usernameQuery))
                parameters["Username"] = usernameQuery;

            try
            {
                List<User> users = await HttpHelper.GetAsync<List<User>>(_baseUrl + "/all", parameters);

                // Map to VM
                return _mapper.Map<List<UserVM>>(users);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}