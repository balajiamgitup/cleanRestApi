using AutoMapper;
namespace WebApplication1.Profiles
{
    public class itemProfile : Profile
    {
        public itemProfile()
        {
            CreateMap<Models.Domain.Item, Models.DTO.item>()
                .ReverseMap();
        }
    }
}
