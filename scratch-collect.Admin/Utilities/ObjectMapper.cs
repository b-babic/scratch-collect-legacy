using AutoMapper;
using scratch_collect.Model;
using scratch_collect.Model.Desktop;

namespace scratch_collect.Admin.Utilities
{
    public class ObjectMapper
    {
        public static IMapper GetMapper()
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<UserDTO, UserVM>()
                    .ForMember(dest => dest.UserPhoto, opt => opt.Condition(src => (src.UserPhoto != null && src.UserPhoto.Length > 0)));

                // Merchant
                config.CreateMap<MerchantDTO, MerchantVM>();
            });

            IMapper mapper = mapperConfiguration.CreateMapper();

            return mapper;
        }
    }
}