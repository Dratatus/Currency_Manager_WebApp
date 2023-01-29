using CurrencyManager.Data.Entities;
using CurrencyManager.Data.Repositories;
using CurrencyManager.WebApp.Models.Services.Profile;
using CurrencyManager.WebApp.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CurrencyManager.WebApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly IProfileService _profileService;
        private readonly IRepositoryBase<User> _repositoryBase;
        public ProfileController(IUserService userService, IRepositoryBase<User> repositoryBase, IProfileService profileService )
        {
            _userService = userService;
            _repositoryBase = repositoryBase;
            _profileService = profileService;
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
            var loggedUser = _userService.LoggedUser;

            bool premiumAccount = _profileService.CheckUserPremiumChanges(user.Passes.Password);


            loggedUser.IsPremium = premiumAccount;
            loggedUser.Passes = user.Passes;
            loggedUser.PersonalInfo = user.PersonalInfo;

            _repositoryBase.SaveChangesAsync();
            return View(loggedUser);
        }
    }
}
