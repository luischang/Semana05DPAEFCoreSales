using Semana05DPAEFCoreSales.DOMAIN.Core.Entities;

namespace Semana05DPAEFCoreSales.DOMAIN.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> Delete(int id);
        Task<Customer> GetCustomer(int id);
        Task<IEnumerable<Customer>> GetCustomerByCountry(string country);
        Task<IEnumerable<Customer>> GetCustomers();
        Task<bool> Insert(Customer customer);
        Task<bool> Update(Customer customer);
        Task<Customer> GetCustomersWithOrders(int id);
    }
}