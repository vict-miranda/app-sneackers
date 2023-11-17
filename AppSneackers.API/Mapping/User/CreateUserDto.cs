using AppSneackers.Domain.ValueObjects;

namespace AppSneackers.API.Mapping.User
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        //public Contact? Contact { get; set; }
    }
}
