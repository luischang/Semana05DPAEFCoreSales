using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana05DPAEFCoreSales.DOMAIN.Core.DTOs
{
    public class UsersDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string RoleCode { get; set; }
        public bool IsActive { get; set; }
    }

    public class UsersLoginResponseDTO 
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string RoleCode { get; set; }
    }

    public class UsersAuthenticationDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
