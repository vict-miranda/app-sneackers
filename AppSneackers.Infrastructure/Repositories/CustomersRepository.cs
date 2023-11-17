using AppSneackers.Domain.Entities;
using AppSneackers.Domain.Repositories;

namespace AppSneackers.Infrastructure.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly AppDbContext _context;

        public CustomersRepository(AppDbContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<Customer> Create(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

    }
}
