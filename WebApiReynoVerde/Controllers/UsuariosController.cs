//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace WebApiReynoVerde.Controllers
//{
//    [ApiController]
//    [Route("api/cuenta")]
//    public class UsuariosController : ControllerBase
//    {

//        private readonly UserManager<IdentityUser> userManager;
//        private readonly SignInManager<IdentityUser> signInManager;
//        private readonly IConfiguration config;

//        public UsuariosController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
//           IConfiguration config)
//        {
//            this.userManager = userManager;
//            this.signInManager = signInManager;
//            this.config = config;
//        }

//        [HttpPost("login")]
//        public async Task<ActionResult<RespuestaLogin>> Login([FromBody] CredencialesUsuario credenciales)
//        {
//            var resultado = await signInManager.PasswordSignInAsync(
//                credenciales.Email, credenciales.Password, isPersistent: false, lockoutOnFailure: false);

//            if (!resultado.Succeeded)
//            {
//                return BadRequest("Login incorrecto");
//            }

//            return ConstruirToken(credenciales);
//        }

//        private RespuestaLogin ConstruirToken(CredencialesUsuario credenciales)
//        {
//            var claims = new List<Claim>()
//        {
//            new Claim(ClaimTypes.Name, credenciales.Email),
//        };

//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtKey"]));
//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
//            var expiracion = DateTime.UtcNow.AddHours(1);

//            var token = new JwtSecurityToken(
//                claims: claims,
//                expires: expiracion,
//                signingCredentials: creds);

//            return new RespuestaLogin()
//            {
//                Token = new JwtSecurityTokenHandler().WriteToken(token),
//                Expiracion = expiracion
//            };
//        }

//    }
//}
