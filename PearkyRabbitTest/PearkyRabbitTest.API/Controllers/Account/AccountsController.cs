using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PearkyRabbitTest.DataAccess.IRepository;
using PearkyRabbitTest.Models.Auth;
using PearkyRabbitTest.Models.Auth.View;
using PearkyRabbitTest.Models.Others.View;
using PearkyRabbitTest.Utilities;
using PerakyRabbitTest.Services;

namespace PearkyRabbitTest.API.Controllers.Account
{
    public class AccountsController : BaseApiController
    {
        private readonly IUnitRepository _unit;
        private readonly UserManager<ApplicationUser> _userManager;
         private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountsController(
            IUnitRepository unit, 
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            SignInManager<ApplicationUser> signInManager

            )
        {
            _unit = unit;
            _userManager = userManager;
            _configuration = configuration;
            _signInManager=signInManager;

        }
        [AllowAnonymous]
        [HttpPost("ifuseremailalreadyexists")]
        public IActionResult IfUserEmailAlreadyExists([FromBody] IfExistsViewModel model) =>
            _unit.Users.IfUserEmailAlreadyExists(model.Id, model.Name) ?
            Ok(new { status = 200, value = true }) :
            Ok(new { status = 200, value = false });

        [AllowAnonymous]
        [HttpPost("ifusernamealreadyexists")]
        public IActionResult IfUserNameAlreadyExists([FromBody] IfExistsViewModel model) =>
            _unit.Users.IfUserNameAlreadyExists(model.Id, model.Name) ?
            Ok(new { status = 200, value = true }) :
            Ok(new { status = 200, value = false });
        [AllowAnonymous]
        [HttpPost("registration")]
        public async Task<IActionResult> RegistrationAsync([FromBody]RegestrationViewModel model)
        {
            if (_unit.Users.IfUserEmailAlreadyExists(Guid.Empty, model.Email))
                return Ok(new { statusCode = 400, message = "Email already taken." });

            if (_unit.Users.IfUserNameAlreadyExists(Guid.Empty, model.UserName))
                return Ok(new { statusCode = 400, message = "User Name already taken." });
            var user = new ApplicationUser()
            {
             
                UserName = model.Email,
                Email = model.Email,
                
                
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, SD.Role_User);
                return Ok(new
                {
                    StatusCode = 200,
                    message = "Registration Complete. Please Login",
                });
            }
            else
            {
                // User creation failed, return error response
                return BadRequest(new
                {
                    StatusCode = 400,
                    Errors = result.Errors
                });
            }
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.UserNameOrEmail);
            if (user == null)
                return Ok(new { statusCode = 401, message = "Invalid Email or Password" });

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded)
                return Ok(new { statusCode = 401, message = "Invalid Email or Password" });


            AuthService authService = new(_userManager, _configuration);

            AuthViewModel token = await authService.GetTokenAsync(user);
            token.RefreshToken = authService.GenerateRefreshToken();
            token.RefreshTokenExpireTime = DateTime.UtcNow.AddDays(Convert.ToDouble(_configuration["Jwt:RefreshDurationInDays"]));

            RefreshToken refreshToken = new()
            {
                Token = token.RefreshToken,
                Expires = token.RefreshTokenExpireTime,
                Created = DateTime.UtcNow,
                ApplicationUserId = user.Id,
                ActualToken = token.Token
            };

            var perviousRefreshTokens = _unit.RefreshToken.GetRefreshTokenByUserId(user.Id);
            await _unit.RefreshToken.RemoveRangeAsync(perviousRefreshTokens);

            await _unit.RefreshToken.AddAsync(refreshToken);

            return Ok(new
            {
                statusCode = 200,
                value = token
            });
        }
    }
}
