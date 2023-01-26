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

        public UserService(IRepositoryBase<User> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task<bool> LoginAsync(string emailAddress, string password)
        {

            var userFound = await _repositoryBase.FindAsync(u => u.Passes.EmailAddress == emailAddress && u.Passes.Password == password);

            bool userExists = userFound.Any();
            if (userExists)
            {
                return userExists;
            }
            else
            {
                throw new Exception("Błędne dane logowania!");
            }
        }

        public async Task RegisterAsync(string emailAddress, string password)
        {
            bool userAlreadyExist = await UserExists(emailAddress);

            if (userAlreadyExist)
            {
                throw new Exception("Podany Email już istnieje w bazie danych!");
            }

            User newUser = new User
            {
                Passes = new Passes
                {
                    EmailAddress = emailAddress,
                    Password = password
                },
                PersonalInfo = new PersonalInfo()
            };

            await _repositoryBase.AddAsync(newUser);
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
    }
}
