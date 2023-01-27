using CurrencyManager.Data.Entities;
using CurrencyManager.WebApp.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System;
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
            try
            {
                bool loginSuccess = await _userService.LoginAsync(passes);

                if (loginSuccess)
                {
                    return Redirect("../Currency/Index");

                }
                else
                {
                    ViewBag.ErrorMessage = "Błędne dane logowania";

                    return View();
                }
            }
            catch (Exception e)
            {

                TempData["errorMessage"] = $"{e.Message}";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Passes passes)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.RegisterAsync(passes.EmailAddress, passes.Password);
                    return Redirect("../Currency/Index");
                }
                catch (Exception e)
                {
                    TempData["errorMessage"] = e.Message;
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}
