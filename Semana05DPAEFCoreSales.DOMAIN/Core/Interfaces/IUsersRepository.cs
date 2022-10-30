using Semana05DPAEFCoreSales.DOMAIN.Core.Entities;

namespace Semana05DPAEFCoreSales.DOMAIN.Core.Interfaces
{
    public interface IUsersRepository
    {
        Task<Users> Login(string email, string password);
    }
}