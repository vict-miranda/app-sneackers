using AppSneackers.Domain.Entities;

namespace AppSneackers.Domain.Repositories
{
    public interface ICustomersRepository
    {
        Task<Customer> Create(Customer customer);
    }
}
