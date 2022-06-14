using escolaNc.Interfaces;
using escolaNc.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace escolaNc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost, Route("cadastro")]
        public IActionResult CadastroUsuario([FromBody] Login login)
        {
            try
            {
                return Ok(_loginService.CadastroUsuario(login));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPost, Route("validar")]
        public IActionResult ValidarUsuario([FromBody] Login login)
        {
            try
            {
                return Ok(_loginService.ValidarUsuario(login));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
