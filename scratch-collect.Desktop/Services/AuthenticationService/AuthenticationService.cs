using scratch_collect.Model.Auth;
using System;
using System.Threading.Tasks;

namespace scratch_collect.Desktop.Services.Authentication
{
    internal class AuthenticationService
    {
        private static string _baseUrl = System.Configuration.ConfigurationManager.AppSettings["BASE_API_URL"] + "auth";

        public static void FakeAuthentication()
        {
            HttpHelper.UpdateAuthorizationHeader("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCIsImN0eSI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiZGVza3RvcEB0ZXN0LmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluaXN0cmF0b3IiLCJuYmYiOjE2NTQyODY5OTUsImV4cCI6MTY1NDg5MTc5NX0.X2hU2fMUKTzHvVlO07UhAXR5xUUKMMll7BAI-AH3yb4");
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
                var user = await HttpHelper.PostAsync<SignedUser, SigninRequest>(_baseUrl + "/signin", request);

                // Save auth token
                if (!string.IsNullOrEmpty(user.Token))
                {
                    HttpHelper.UpdateAuthorizationHeader(user.Token);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //TODO: Logout ?
    }
}