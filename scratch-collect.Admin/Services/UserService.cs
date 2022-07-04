using AutoMapper;
using scratch_collect.Admin.Services;
using scratch_collect.Admin.Utilities;
using scratch_collect.Model;
using scratch_collect.Model.Desktop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.Desktop.Services
{
    public class UserService
    {
        private static string _baseUrl = System.Configuration.ConfigurationManager.AppSettings["BASE_API_URL"] + "user";
        private static IMapper _mapper = ObjectMapper.GetMapper();

        public UserService()
        {
        }

        public static async Task<List<UserVM>> GetAllUsers(string emailQuery = null, string usernameQuery = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(emailQuery))
                parameters["Email"] = emailQuery;

            if (!string.IsNullOrEmpty(usernameQuery))
                parameters["Username"] = usernameQuery;

            try
            {
                List<UserDTO> users = await BaseService.GetAsync<List<UserDTO>>(_baseUrl + "/all", parameters);

                // Map to VM
                return _mapper.Map<List<UserVM>>(users);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<UserVM> GetUserById(string userID)
        {
            try
            {
                UserDTO user = await BaseService.GetAsync<UserDTO>(_baseUrl + string.Format("/{0}", userID));

                // Map to VM
                return _mapper.Map<UserVM>(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<UserVM> CreateUser(UserCreateVM user)
        {
            try
            {
                var createdUser = await BaseService.PostAsync<UserDTO, UserCreateVM>(_baseUrl, user);

                return _mapper.Map<UserVM>(createdUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<UserVM> UpdateUser(UserUpdateVM user)
        {
            try
            {
                var updatedUser = await BaseService.PutAsync<UserVM, UserUpdateVM>(_baseUrl + string.Format("/{0}", user.Id), user);

                return _mapper.Map<UserVM>(updatedUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<bool> DeleteUser(int id)
        {
            try
            {
                var response = await BaseService.DeleteAsync(_baseUrl + string.Format("/{0}", id));

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Won items
        public static async Task<List<UserOfferDTO>> AllWonOffers(DateTime? dateFrom, DateTime? dateTo)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            if (dateFrom != null)
                parameters["TimeFrom"] = dateFrom.ToString();

            if (dateTo != null)
                parameters["TimeTo"] = dateTo.ToString();

            try
            {
                var items = await BaseService.GetAsync<List<UserOfferDTO>>(_baseUrl + "/won/all", parameters);

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