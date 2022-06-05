using AutoMapper;
using scratch_collect.Model;
using scratch_collect.Model.Desktop;
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
                List<UserDTO> users = await HttpHelper.GetAsync<List<UserDTO>>(_baseUrl + "/all", parameters);

                // Map to VM
                return _mapper.Map<List<UserVM>>(users);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserVM> CreateUser(UserCreateVM user)
        {
            try
            {
                var createdUser = await HttpHelper.PostAsync<UserDTO, UserCreateVM>(_baseUrl, user);

                return _mapper.Map<UserVM>(createdUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var response = await HttpHelper.DeleteAsync(_baseUrl + string.Format("/{0}", id));

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}