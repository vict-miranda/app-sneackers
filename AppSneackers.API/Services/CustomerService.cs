using AppSneackers.API.Services.Interfaces;
using AppSneackers.Domain.Entities;
using AppSneackers.Domain.Repositories;

namespace AppSneackers.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomerService(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<Customer> Create()
        {
            var customer = new Customer
            {
                Name = "Willow",
                Contact = new()
                {
                    Address = new("a", "b", "c", "d", "e"),
                    HomePhone = new (56, 65465465),
                    MobilePhone = new(56, 65465465),
                    WorkPhone = new(56, 65465465),
                }
            };

            customer.Orders.Add(new Order { 
                BillingAddress = new("a", "b", "c", "d", "e"),
                ShippingAddress = new("a", "b", "c", "d", "e"),
                Contents = "xxx",
                ContactPhone = new(12, 654)
            });

            await _customersRepository.Create(customer);
            return customer;
        }

    }
}
