using AppSneackers.Domain.ValueObjects;

namespace AppSneackers.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public required string Contents { get; set; }
        public required PhoneNumber ContactPhone { get; set; }
        public required Address ShippingAddress { get; set; }
        public required Address BillingAddress { get; set; }
        public Customer Customer { get; set; } = null!;
    }
}
