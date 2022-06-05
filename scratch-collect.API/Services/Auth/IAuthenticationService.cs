using scratch_collect.Model;
using scratch_collect.Model.Requests;

namespace scratch_collect.API.Services
{
    public interface IAuthenticationService
    {
        UserDTO Signup(SignupRequest request);

        SignedUserDTO Signin(SigninRequest request);
    }
}