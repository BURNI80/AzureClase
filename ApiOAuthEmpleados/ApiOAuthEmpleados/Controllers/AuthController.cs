using ApiOAuthEmpleados.Helpers;
using ApiOAuthEmpleados.Models;
using ApiOAuthEmpleados.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace ApiOAuthEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private RepositoryEmpleados repo;
        private HelperOAuthToken helper;

        public AuthController(RepositoryEmpleados repo, HelperOAuthToken helper)
        {
            this.repo = repo;
            this.helper = helper;
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model)
        {
            Empleado empleado = await this.repo.ExisteEmpleadoAsync(model.Username, model.Password);
            if(empleado == null)
            {
                return Unauthorized();
            }
            else
            {
                SigningCredentials credentials = new SigningCredentials(this.helper.GetKeyToken(), SecurityAlgorithms.HmacSha256);
                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: this.helper.Issuer,
                    audience: this.helper.Audience,
                    signingCredentials: credentials,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    notBefore: DateTime.UtcNow
                    );

                return Ok(new
                {
                    response = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
        }

    }
}
