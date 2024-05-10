using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vendagas.API.Application.Services.Token;
using Vendagas.API.Application.Services.User;
using Vendagas.API.ORM.Entity;
using Vendagas.API.ORM.Model.User;

namespace Vendagas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        public UserController(IUserService userService, ITokenService tokenService, IConfiguration configuration)
        {
            _userService = userService;
            _tokenService = tokenService;
            _configuration = configuration;
        }


        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] UserRequestModel loginModel)
        {
            if (loginModel == null)
            {
                return BadRequest("Credenciais inválidas");
            }

            bool isAuthenticated = await _userService.ValidateCredentials(loginModel.Email, loginModel.Password);

            if (isAuthenticated)
            {
                UserModel user = await _userService.GetUserByEmailAsync(loginModel.Email);

                var tokenString = _tokenService.GenerateToken(
                    _configuration["Jwt:Key"],
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    user
                );

                return Ok(new { token = tokenString, username = user.Username });
            }
            else
            {
                return BadRequest("Credenciais inválidas");
            }
        }

        [HttpPost("create-user")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateUser([FromBody] CreateUserModel userModel)
        {
            if (userModel == null)
            {
                return BadRequest("Dados do usuário inválidos");
            }

            UserModel createdUser = _userService.CreateUser(userModel);

            if (createdUser != null)
            {
                return Ok(new { message = "Usuário criado com sucesso" });
            }
            else
            {
                return BadRequest("Falha ao criar usuário");
            }
        }
    }
}
