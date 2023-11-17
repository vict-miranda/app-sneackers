using System.ComponentModel.DataAnnotations.Schema;

namespace AppSneackers.Domain.ValueObjects
{
    [ComplexType]
    public record PhoneNumber(int CountryCode, long Number);
}
