using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Semana05DPAEFCoreSales.DOMAIN.Core.Entities;
using Semana05DPAEFCoreSales.DOMAIN.Core.Interfaces;

namespace Semana05DPAEFCoreSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerRepository.GetCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetCustomer(id);
            return Ok(customer);
        }

        [HttpGet("GetByCountry")]
        public async Task<IActionResult> GetByCountry([FromQuery] string country)
        {
            var customer = await _customerRepository.GetCustomerByCountry(country);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Customer customer)
        {
            var result = await _customerRepository.Insert(customer);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id)
                return BadRequest();

            var result = await _customerRepository.Update(customer);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var result = await _customerRepository.Delete(id);
            return Ok(result);
        }


    }
}
