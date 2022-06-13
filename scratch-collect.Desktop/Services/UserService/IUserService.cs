﻿using scratch_collect.Model;
using scratch_collect.Model.Desktop;
using scratch_collect.Model.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.Desktop.Services
{
    public interface IUserService
    {
        public Task<List<UserVM>> GetAllUsers(string emailQuery = null, string usernameQuery = null);

        public Task<UserVM> GetUserById(string userID);

        public Task<UserVM> CreateUser(UserCreateVM user);

        public Task<UserVM> UpdateUser(UserUpdateVM user);

        public Task<bool> DeleteUser(int id);

        // Won items
        public Task<List<UserOfferDTO>> AllWonOffers(DateTime? dateFrom = null, DateTime? dateTo = null);
    }
}