using scratch_collect.Model.Auth;
using scratch_collect.Model.User;

namespace scratch_collect.API.Services
{
    public interface IAuthenticationService
    {
        User Signup(SignupRequest request);

        SignedUser Signin(SigninRequest request);
    }
}