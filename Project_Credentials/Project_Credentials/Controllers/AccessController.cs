using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using WebService.Core.Interfaces;
using WebService.Domain.DTOs;
namespace Project_Credentials.Controllers
{

    public class AccessController : Controller
    {
        private readonly IUserService userService;
        public AccessController(IUserService _userService) {
            userService = _userService;
        }
        public IActionResult Index()
        {
            return View();

        }

        public IActionResult SigningUpForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginRquestDto user)
        {
            try
            {
                var authUser = await userService.UserValidation(user.Email, user.Password);

                if (authUser != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, authUser.Name),
                        new Claim(ClaimTypes.UserData, authUser.Email),
                        new Claim(ClaimTypes.NameIdentifier, authUser.Id.ToString())
                    };

                    claims.Add(new Claim(ClaimTypes.Role, authUser.Rol.Name));

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    //Se esta creando una cookie
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));

                }


                return authUser == null ? View() : RedirectToAction("Index", "Home");

            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "Home");
            }
            
           
        }


        [HttpPost]
        public async Task<IActionResult> SignUp(UserRequestDto userData)
        {
            try
            {
                 await userService.Insert(userData);



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return RedirectToAction("Index", "access");

        }


        public async Task<IActionResult> Exit()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Access"); 
        }

    }
}
