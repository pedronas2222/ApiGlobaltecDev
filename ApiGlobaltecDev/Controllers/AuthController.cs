using ApiGlobaltecDev.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;



namespace ApiGlobaltecDev.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string Usuario, string Senha)
        {
            if (Usuario == "pedro" && Senha == "123")
            {
                var token = TokenService.GenerateToken(new ApiGlobaltecDev.Models.PessoasModel());
                return Ok(token);
            }

            return BadRequest("Usuário ou senha inválidos.");
        }
    }
}