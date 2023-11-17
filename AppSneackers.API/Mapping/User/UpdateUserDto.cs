using AppSneackers.API.Mapping.Sneacker;

namespace AppSneackers.API.Mapping.User
{
    public class UpdateUserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<SneackerDto> Sneackers { get; set; }
    }
}
