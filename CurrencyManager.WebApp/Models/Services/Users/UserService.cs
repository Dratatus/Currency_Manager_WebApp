using CurrencyManager.Data.Entities;
using CurrencyManager.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyManager.WebApp.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IRepositoryBase<User> _repositoryBase;

        private User StandardTestUser { get; set; }
        private User PremiumTestUser { get; set; }
        public User LoggedUser { get; set; }

        public UserService(IRepositoryBase<User> repositoryBase)
        {
            _repositoryBase = repositoryBase;
            StandardTestUser = new User
            {
                IsPremium = false,

                Passes = new Passes
                {
                    EmailAddress = "standard@user.pl",
                    Password = "1qazXSW@#",

                },
                PersonalInfo = new PersonalInfo
                {
                    Age = 20,
                    Name = "standard",
                    Surname = "User",
                }
            };
            PremiumTestUser = new User
            {
                IsPremium = true,

                Passes = new Passes
                {
                    EmailAddress = "premium@user.pl",
                    Password = "1qazXSW@#premium",

                },
                PersonalInfo = new PersonalInfo
                {
                    Age = 20,
                    Name = "Premium",
                    Surname = "User",
                }
            };

        }

        public async Task<bool> LoginAsync(Passes passes)
        {
            var usersFound = await _repositoryBase.FindAsync(u => u.Passes.EmailAddress == passes.EmailAddress && u.Passes.Password == passes.Password);
            bool userExists = usersFound.Any();

            if (userExists)
            {

                if (passes.Password == "1qazXSW@#premium")
                {
                    foreach (var user in usersFound)
                    {
                        user.IsPremium = true;
                        LoggedUser = user;
                    }
                    return userExists;
                }

                else
                {
                    foreach (var user in usersFound)
                    {
                        LoggedUser = user;
                    }
                    return userExists;
                }
            }

            else if (!userExists)
            {
                if (passes.EmailAddress == "standard@user.pl" && passes.Password == "1qazXSW@#")
                {
                    LoggedUser = StandardTestUser;
                    return true;
                }

                else if (passes.EmailAddress == "premium@user.pl" && passes.Password == "1qazXSW@#premium")
                {
                    LoggedUser = PremiumTestUser;
                    return true;
                }

                throw new Exception("Incorrect login data!");
            }

            else
            {
                throw new Exception("Incorrect login data!");
            }
        }

        public async Task RegisterAsync(string email, string password)
        {
            bool userAlreadyExist = await UserExists(email);

            var users = _repositoryBase.FindAsync(u => u.Passes.EmailAddress == email);

            if (userAlreadyExist)
            {
                throw new Exception("The specified Email already exists!");
            }
            if (password == "1qazXSW@#premium")
            {
                User newUser = new User
                {
                    IsPremium = true,

                    Passes = new Passes
                    {
                        EmailAddress = email,
                        Password = password,

                    },
                    PersonalInfo = new PersonalInfo
                    {
                        Age = 0,
                        Name = "Name",
                        Surname = "Surname",
                    }

                };

                LoggedUser = newUser;
                await _repositoryBase.AddAsync(newUser);
            }
            else
            {
                User newUser = new User
                {
                    IsPremium = false,

                    Passes = new Passes
                    {
                        EmailAddress = email,
                        Password = password,

                    },
                    PersonalInfo = new PersonalInfo
                    {
                        Age = 0,
                        Name = "Name",
                        Surname = "Surname",
                    },

                };

                LoggedUser = newUser;

                await _repositoryBase.AddAsync(newUser);
            }
        }

        public void Logout()
        {
            LoggedUser = null;
        }

        public async Task<bool> UserExists(string emailAddress)
        {
            var userFound = await _repositoryBase.FindAsync(u => u.Passes.EmailAddress == emailAddress);

            bool userAlreadyExist = userFound.Any();

            return userAlreadyExist;
        }


        public bool IsUserLogged()
        {
            if (LoggedUser != null)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

    }
}
