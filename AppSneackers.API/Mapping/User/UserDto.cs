using AppSneackers.API.Mapping.Sneacker;
using AppSneackers.Domain.ValueObjects;

namespace AppSneackers.API.Mapping.User
{
    public class UserDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; } = string.Empty;

        //public string Password { get; private set; }

        public Contact? Contact { get; set; }

        public List<SneackerDto> Sneackers { get; set; }
    }
}
