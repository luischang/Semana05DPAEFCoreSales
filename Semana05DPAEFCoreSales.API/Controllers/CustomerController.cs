using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Semana05DPAEFCoreSales.DOMAIN.Core.DTOs;
using Semana05DPAEFCoreSales.DOMAIN.Core.Entities;
using Semana05DPAEFCoreSales.DOMAIN.Core.Interfaces;

namespace Semana05DPAEFCoreSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerRepository.GetCustomers();
            //Convert customers to customerDTO
            //var customerList = new List<CustomerDTO>();
            //foreach (var item in customers)
            //{
            //    customerList.Add(new CustomerDTO
            //    {
            //        Id = item.Id,
            //        FirstName = item.FirstName,
            //        LastName = item.LastName,
            //        City = item.City,
            //        Country = item.Country,
            //        Phone = item.Phone
            //    });
            //}
            var customerList = _mapper.Map<List<CustomerCountryDTO>>(customers);
            return Ok(customerList);
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
        public async Task<IActionResult> Insert([FromBody] CustomerCreateDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);

            var result = await _customerRepository.Insert(customer);
            return Ok(new { response = result });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerDTO customerDTO)
        {
            if (id != customerDTO.Id)
                return BadRequest();

            var customer = _mapper.Map<Customer>(customerDTO);

            var result = await _customerRepository.Update(customer);
            return Ok((new { response = result }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var result = await _customerRepository.Delete(id);
            return Ok((new { response = result }));
        }

        [HttpGet("GetOrdersByCustomer/{id}")]
        public async Task<IActionResult> GetOrdersByCustomer(int id)
        {
            var customer = await _customerRepository.GetCustomersWithOrders(id);
            if (customer == null)
                return NotFound();

            var customerDTO = _mapper.Map<CustomerOrderDTO>(customer);
            return Ok(customerDTO);
        }
    }
}
