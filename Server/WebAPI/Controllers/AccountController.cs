namespace WebAPI.Controllers
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.Extensions.Configuration;

    using Dtos;
    using Interfaces;
    using Models;

    public class AccountController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;

        public AccountController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequest)
        {
            var user = await this.unitOfWork.UserRepository.Authenticate(loginRequest.Username, loginRequest.Password);

            if (user == null)
            {
                return this.Unauthorized();
            }

            var loginResponse = new LoginResponseDto();

            loginResponse.Username = user.Username;
            loginResponse.Token = CreateJWT(user);


            return this.Ok(loginResponse);
        }

        public string CreateJWT(User user)
        {
            var secretKey = configuration.GetSection("AppSettings:Key").Value;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var claims = new Claim[] {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
