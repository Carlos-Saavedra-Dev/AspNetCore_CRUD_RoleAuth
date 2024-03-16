using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebService.Core.Integrations;
using WebService.Core.Interfaces;
using WebService.Domain.DTOs;

namespace WebService.Application.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class UserController : Controller
    {

        private readonly IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }
        [HttpGet("UserData")]
        public ActionResult<UserDataDto> GetUserData()
        {
            UserDataDto userData = new UserDataDto()
            {
                Name = User.FindFirst(ClaimTypes.Name).Value,
                Email = User.FindFirst(ClaimTypes.UserData).Value
            };

            return userData;
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UserDataDto userData)
        {

            userData.Id = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            await userService.Update(userData);

            return NoContent();
        }


        [HttpPost("Delete")]
        public async Task<IActionResult> Delete()
        {

            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            await userService.Delete(userId);

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);


            return NoContent();

        }


    }
}
