using scratch_collect.Model.Auth;
using scratch_collect.Model.ValidationError;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scratch_collect.Desktop.Services
{
    internal class AuthenticationService
    {
        private static string _baseUrl = System.Configuration.ConfigurationManager.AppSettings["BASE_API_URL"] + "auth";

        public static async Task<bool> Login(string username, string password)
        {
            SigninRequest request = new SigninRequest()
            {
                Email = username,
                Password = password
            };

            try
            {
                var user = await HttpHelper.PostAsync<SignedUser, SigninRequest>(_baseUrl + "/signin", request);

                // Save auth token
                if (!string.IsNullOrEmpty(user.Token))
                {
                    HttpHelper.UpdateAuthorizationHeader(user.Token);
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //TODO: Logout ?
    }
}