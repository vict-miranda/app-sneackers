using AppSneackers.Domain.ValueObjects;

namespace AppSneackers.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; } = string.Empty;

        public string Password { get; private set; }

        public Contact Contact { get; set; }

        public List<Sneacker> Sneackers { get; } = new();
    }
}
