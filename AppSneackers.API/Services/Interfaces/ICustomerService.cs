using AppSneackers.Domain.Entities;

namespace AppSneackers.API.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> Create();
    }
}
