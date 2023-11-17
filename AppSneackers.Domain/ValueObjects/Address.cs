using System.ComponentModel.DataAnnotations.Schema;

namespace AppSneackers.Domain.ValueObjects
{
    [ComplexType]
    public record Address(string Line1, string? Line2, string City, string Country, string PostCode);
}
