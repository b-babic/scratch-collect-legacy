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
        
        UserDTO EditProfile(int id, EditProfileRequest request);


        void Delete(int id);

        // User coupons
        public List<CouponDTO> GetUsersCoupons(int id);

        // Won items
        public List<UserOfferDTO> UserWonItems(UsserOfferSearchRequest request);

        public List<UserOfferDTO> AllWonItems(UsserOfferSearchRequest request);
    }
}