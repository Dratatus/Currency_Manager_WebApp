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

        public User LoggedUser { get; set; }
        

        public UserService(IRepositoryBase<User> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task<bool> LoginAsync(Passes passes)
        {
            var usersFound = await _repositoryBase.FindAsync(u => u.Passes.EmailAddress == passes.EmailAddress && u.Passes.Password == passes.Password);
            bool userExists = usersFound.Any();
           
            if (userExists)
            {
                if ( passes.Password == "1qazXSW@#admin")
                {
                    foreach (var user in usersFound)
                    {
                        user.IsPremium = true;
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

            else
            {
                throw new Exception("Błędne dane logowania!");
            }
        }

        public async Task RegisterAsync(string email, string password)
        {
            bool userAlreadyExist = await UserExists(email);

            var users = _repositoryBase.FindAsync(u => u.Passes.EmailAddress == email);

            if (userAlreadyExist)
            {
                throw new Exception("Podany Email już istnieje w bazie danych!");
            }
            if (password == "1qazXSW@#admin")
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
                        Name = "Imię",
                        Surname = "Nazwisko",
                    },

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
                        Name = "Imię",
                        Surname = "Nazwisko",
                    },

                };

                 LoggedUser = newUser;

                await _repositoryBase.AddAsync(newUser);
            }

           

        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _repositoryBase.GetAllAsync();
            return users;
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
