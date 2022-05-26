using scratch_collect.Model.User;
using System.Collections.Generic;

namespace scratch_collect.API.Services
{
    public interface IUserService
    {
        List<User> Get(UserSearchRequest request);

        User GetById(int id);

        User Insert(UserUpsertRequest request);

        User Update(int id, UserUpsertRequest request);

        // TODO: add user profile edit action
    }
}