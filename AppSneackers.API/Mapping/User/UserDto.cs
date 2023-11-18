using AppSneackers.API.Mapping.Sneacker;
using AppSneackers.Domain.ValueObjects;

namespace AppSneackers.API.Mapping.User
{
    public class UserDto
    {
        public int Id { get; set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; } = string.Empty;

        //public string Password { get; private set; }

        public Contact? Contact { get; set; }

        public List<SneackerDto> Sneackers { get; set; }
    }
}
