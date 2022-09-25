using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Semana05DPAEFCoreSales.DOMAIN.Core.Entities;
using Semana05DPAEFCoreSales.DOMAIN.Core.Interfaces;
using Semana05DPAEFCoreSales.DOMAIN.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana05DPAEFCoreSales.DOMAIN.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SalesDAWContext _context;

        public CustomerRepository(SalesDAWContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var customers = await _context.Customer.ToListAsync();
            return customers;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            //_context.Customer.Find(id);
            return await _context.Customer.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomerByCountry(string country)
        {
            var customers = await _context.Customer.Where(x => x.Country == country).ToListAsync();
            return customers;
        }

        public async Task<bool> Insert(Customer customer)
        {
            await _context.Customer.AddAsync(customer);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(Customer customer)
        {
            _context.Customer.Update(customer);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
                return false;

            _context.Customer.Remove(customer);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);

        }

    }
}
