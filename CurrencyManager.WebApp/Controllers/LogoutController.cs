using CurrencyManager.WebApp.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyManager.WebApp.Controllers
{
    public class LogoutController : Controller
    {
        private readonly IUserService _userService;

        public LogoutController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Logout()
        {
            _userService.Logout();
            return Redirect("../Login/Login");
        }
    }
}
