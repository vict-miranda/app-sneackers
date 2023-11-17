using AutoMapper;

namespace AppSneackers.API.Mapping.User
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, Domain.Entities.User>().ReverseMap();
        }
    }
}
