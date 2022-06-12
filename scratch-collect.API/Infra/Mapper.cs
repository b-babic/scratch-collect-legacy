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

            // Wallet
            CreateMap<Database.Wallet, WalletDTO>();
            CreateMap<Database.Wallet, WalletUpsertRequest>().ReverseMap();

            // Coupon
            CreateMap<Database.Coupon, MerchantDTO>();

            // Merchant
            CreateMap<Database.Merchant, MerchantDTO>();
            CreateMap<Database.Merchant, MerchantUpsertRequest>().ReverseMap();

            // Country
            CreateMap<Database.Country, CountryDTO>();

            // Offer
            CreateMap<Database.Offer, OfferDTO>();
            CreateMap<Database.Offer, OfferUpsertRequest>().ReverseMap();

            // Category
            CreateMap<Database.Category, CategoryDTO>();
        }
    }
}