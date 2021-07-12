using System;
using System.Collections.Generic;
using scratch_collect.Model.Requests;
using scratch_collect.Model.User;

namespace scratch_collect.API.Services
{
    public interface IUserService
    {
        List<User> Get(UserSearchRequest request);
        User GetById(int id);
        User Insert(UserUpsertRequest request);
        User Update(int id, UserUpsertRequest request);
    }
}