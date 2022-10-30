using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Semana05DPAEFCoreSales.DOMAIN.Core.DTOs;
using Semana05DPAEFCoreSales.DOMAIN.Core.Interfaces;

namespace Semana05DPAEFCoreSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UsersController(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UsersAuthenticationDTO auth)
        {
            var user = await _usersRepository.Login(auth.Email, auth.Password);
            if (user == null)
                return NotFound();

            var userDTO = _mapper.Map<UsersLoginResponseDTO>(user);
            return Ok(userDTO);        
        }




    }
}
