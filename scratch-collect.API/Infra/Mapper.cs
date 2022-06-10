using AutoMapper;
using scratch_collect.Model;
using scratch_collect.Model.Requests;

namespace scratch_collect.API.Infra
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            // Auth
            CreateMap<Database.User, SignedUserDTO>();
            CreateMap<Database.User, SignupRequest>().ReverseMap();

            // User
            CreateMap<Database.User, UserDTO>();
            CreateMap<Database.User, UserUpsertRequest>().ReverseMap();

            // Role
            CreateMap<Database.Role, RoleDTO>();

            // Coupon
            CreateMap<Database.Coupon, MerchantDTO>();

            // Merchant
            CreateMap<Database.Merchant, MerchantDTO>();

            // Country
            CreateMap<Database.Country, CountryDTO>();
        }
    }
}