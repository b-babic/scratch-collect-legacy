using AutoMapper;
using scratch_collect.Model;
using scratch_collect.Model.Desktop;
using scratch_collect.Model.Requests;
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
            Dictionary<string, string> parameters = new Dictionary<string, string>();

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

        public async Task<UserVM> GetUserById(string userID)
        {
            try
            {
                UserDTO user = await HttpHelper.GetAsync<UserDTO>(_baseUrl + string.Format("/{0}", userID));

                // Map to VM
                return _mapper.Map<UserVM>(user);
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

        public async Task<UserVM> UpdateUser(UserUpdateVM user)
        {
            try
            {
                var updatedUser = await HttpHelper.PutAsync<UserVM, UserUpdateVM>(_baseUrl + string.Format("/{0}", user.Id), user);

                return _mapper.Map<UserVM>(updatedUser);
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

        // Won items
        public async Task<List<UserOfferDTO>> AllWonOffers(DateTime? dateFrom, DateTime? dateTo)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            if (dateFrom != null)
                parameters["TimeFrom"] = dateFrom.ToString();

            if (dateTo != null)
                parameters["TimeTo"] = dateTo.ToString();

            try
            {
                var items = await HttpHelper.GetAsync<List<UserOfferDTO>>(_baseUrl + "/won/all", parameters);

                // Map to VM
                return _mapper.Map<List<UserOfferDTO>>(items);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}