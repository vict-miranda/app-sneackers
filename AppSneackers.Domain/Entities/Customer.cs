using AppSneackers.Domain.ValueObjects;

namespace AppSneackers.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required Contact Contact { get; set; }
        public List<Order> Orders { get; } = new();
    }
}
