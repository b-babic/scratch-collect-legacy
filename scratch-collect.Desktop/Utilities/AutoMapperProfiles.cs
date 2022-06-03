using AutoMapper;
using scratch_collect.Model.User;
using scratch_collect.Model.User.Desktop;
using System.Linq;

namespace scratch_collect.Desktop.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserVM>()
                // Get only first role since user cannot have multiple roles for Desktop.
                .ForMember(dest => dest.UserRole, opt => opt.MapFrom(src => src.UserRoles.FirstOrDefault().Role.Name))
                .ForMember(dest => dest.UserPhoto, opt => opt.Condition(src => (src.UserPhoto.Length > 0)));
        }
    }
}