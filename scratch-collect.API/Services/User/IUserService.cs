using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System.Collections.Generic;

namespace scratch_collect.API.Services
{
    public interface IUserService
    {
        List<UserDTO> Get(UserSearchRequest request);

        UserDTO GetById(int id);

        UserDTO Insert(UserUpsertRequest request);

        UserDTO Update(int id, UserUpsertRequest request);

        void Delete(int id);

        // TODO: add user profile edit action
    }
}