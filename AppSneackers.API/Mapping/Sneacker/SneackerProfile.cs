using AutoMapper;

namespace AppSneackers.API.Mapping.Sneacker
{
    public class SneackerProfile : Profile
    {
        public SneackerProfile()
        {
            CreateMap<SneackerDto, Domain.Entities.Sneacker>().ReverseMap();
        }
    }
}
