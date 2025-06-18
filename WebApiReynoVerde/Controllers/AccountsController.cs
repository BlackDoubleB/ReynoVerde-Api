//using AutoMapper;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using WebApiReynoVerde.DTO;

//namespace WebApiReynoVerde.Controllers
//{
//    [Route("api/accounts")]
//    [ApiController]
//    public class AccountsController : ControllerBase
//    {
//        private readonly UserManager<IdentityUser> _userManager;
//        private readonly IMapper _mapper;

//        public AccountsController(UserManager<IdentityUser> userManager, IMapper mapper)
//        {
//            _userManager = userManager;
//            _mapper = mapper;
//        }

//        [HttpPost("Register")]
//        public async Task<IActionResult> Register([FromBody] UserFormRegistrationDto userFormRegistrationDto)
//        {
//            if (userFormRegistrationDto is null)
//            {
//                return BadRequest();
//            }
//            var user = _mapper.Map<IdentityUser>(userFormRegistrationDto);
//            var result = await _userManager.CreateAsync(user, userFormRegistrationDto.Password);
            
//            if (!result.Succeeded)
//            {
//                var errors = result.Errors.Select(e => e.Description);
//                return BadRequest(new RegistrationResponseDto { Errors = errors });
//            }
//            return StatusCode(201);
            
//        }
//    }
//}
