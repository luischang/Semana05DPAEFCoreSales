using Microsoft.EntityFrameworkCore;
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
    public class UsersRepository : IUsersRepository
    {
        private readonly SalesDAWContext _context;

        public UsersRepository(SalesDAWContext context)
        {
            _context = context;
        }

        public async Task<Users> Login(string email, string password)
        {
            var user = await _context
                        .Users
                        .Where(x => x.Email == email && x.Password == password && x.IsActive == true)
                        .FirstOrDefaultAsync();
            return user;
        }
    }
}
