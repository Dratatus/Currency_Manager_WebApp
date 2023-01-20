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
            var userFound = await _repositoryBase.FindAsync(u => u.EmailAddress == emailAddress && u.Password == password);

            bool userExists = userFound.Any();

            return userExists;
        }

        public async Task<bool> RegisterAsync(string emailAddress, string password)
        {
            // todo: walidacja danych

            bool userAlreadyExist = await IsUserExist(emailAddress);

            if (userAlreadyExist)
            {
                throw new Exception("Podany Email już istnieje w bazie danych!");
            }
            else
            {
                User newUser = new User { EmailAddress = emailAddress, Password = password };
                var userToRegister = await _repositoryBase.AddAsync(newUser);

                return true;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _repositoryBase.GetAllAsync();
            return users;
        }

        public async Task<bool> IsUserExist(string emailAddress)
        {
            var userFound = await _repositoryBase.FindAsync(u => u.EmailAddress == emailAddress);

            bool userAlreadyExist = userFound.Any();

            return  userAlreadyExist;
        }
    }
}
