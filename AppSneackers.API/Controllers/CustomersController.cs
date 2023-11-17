using AppSneackers.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppSneackers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var response = await _customerService.Create();
            return Ok(response);
        }
    }
}
