using AutoMapper;

namespace WebApplication1.Profiles
{
    public class OrderProfile :Profile
    {

        public OrderProfile()
        {
            CreateMap<Models.Domain.order, Models.DTO.Order>()
               .ReverseMap();
        }
    }
}
