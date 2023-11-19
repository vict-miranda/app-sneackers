using AutoMapper;

namespace AppSneackers.API.Mapping.Sneacker
{
    public class SneackerProfile : Profile
    {
        public SneackerProfile()
        {
            CreateMap<SneackerDto, Domain.Aggregates.Sneacker>().ReverseMap();
        }
    }
}
