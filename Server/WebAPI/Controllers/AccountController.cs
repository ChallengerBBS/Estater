namespace WebAPI.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    
    using WebAPI.Dtos;
    using WebAPI.Interfaces;
    
    public class AccountController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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
            loginResponse.Token = "Token to be generated";


            return this.Ok(loginResponse);
        }
    }
}
