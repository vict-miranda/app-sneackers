using System.ComponentModel.DataAnnotations.Schema;

namespace AppSneackers.Domain.ValueObjects
{
    [ComplexType]
    public record Contact
    {
        public Address Address { get; init; }
        public PhoneNumber HomePhone { get; init; }
        public PhoneNumber WorkPhone { get; init; }
        public PhoneNumber MobilePhone { get; init; }
    }
}
