using AutoMapper;
using scratch_collect.Model.Auth;
using scratch_collect.Model.Coupon;
using scratch_collect.Model.Role;
using scratch_collect.Model.User;
using scratch_collect.Model.UserRole;

namespace scratch_collect.API.Infra
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            // auth
            CreateMap<Database.User, SignedUser>();
            CreateMap<Database.User, SignupRequest>().ReverseMap();

            // user
            CreateMap<Database.User, User>();
            CreateMap<Database.User, UserUpsertRequest>().ReverseMap();

            // user role
            CreateMap<Database.UserRole, UserRole>().ReverseMap();

            // role
            CreateMap<Database.Role, Role>();

            // coupons
            CreateMap<Database.Coupon, CouponModel>();
        }
    }
}