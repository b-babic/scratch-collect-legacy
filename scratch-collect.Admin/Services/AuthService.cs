using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System;
using System.Threading.Tasks;

namespace scratch_collect.Admin.Services
{
    public static class AuthService
    {
        private static string _baseUrl = System.Configuration.ConfigurationManager.AppSettings["BASE_API_URL"] + "auth";

        public static void FakeAuthentication()
        {
            BaseService.UpdateAuthorizationHeader(System.Configuration.ConfigurationManager.AppSettings["DEV_AUTH_TOKEN"]);
        }

        public static async Task<bool> Login(string username, string password)
        {
            SigninRequest request = new SigninRequest()
            {
                Email = username,
                Password = password
            };

            try
            {
                var user = await BaseService.PostAsync<SignedUserDTO, SigninRequest>(_baseUrl + "/signin", request);

                // Save auth token
                if (!string.IsNullOrEmpty(user.Token))
                {
                    BaseService.UpdateAuthorizationHeader(user.Token);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}