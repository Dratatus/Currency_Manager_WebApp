using CurrencyManager.WebApp.Models;
using CurrencyManager.WebApp.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CurrencyManager.WebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Passes passes)
        {
            bool loginSuccess = await _userService.LoginAsync(passes.EmailAddress, passes.Password);

            if (loginSuccess)
            {
                return Redirect("Currency/Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Błędne dane logowania";

                return View();
            }
        }
    }
}
