using AutoMapper;
using scratch_collect.Model;
using scratch_collect.Model.Desktop;

namespace scratch_collect.Desktop.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserDTO, UserVM>()
                // Get only first role since user cannot have multiple roles for Desktop.
                .ForMember(dest => dest.UserPhoto, opt => opt.Condition(src => (src.UserPhoto != null && src.UserPhoto.Length > 0)));
        }
    }
}