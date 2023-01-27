using CurrencyManager.Data.Entities;
using CurrencyManager.Data.Repositories;
using CurrencyManager.WebApp.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CurrencyManager.WebApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRepositoryBase<User> _repositoryBase;
        public ProfileController(IUserService userService, IRepositoryBase<User> repositoryBase)
        {
            _userService = userService;
            _repositoryBase = repositoryBase;
        }
        [HttpGet]
        public IActionResult Profile()
        {
            bool userLogged =_userService.IsUserLogged();

            if (userLogged)
            {
                var user = _userService.LoggedUser;


                return View(user);
            }
            else
            {
                throw new Exception("Musisz się najpierw zalogować!");
            }
           
            
        }

        [HttpPost]
        public IActionResult Profile(User user)
        {
            var loogedUser = _userService.LoggedUser;

            loogedUser.Passes = user.Passes;
            loogedUser.PersonalInfo = user.PersonalInfo;

            _repositoryBase.SaveChangesAsync();
            return View(loogedUser);
        }
    }
}
