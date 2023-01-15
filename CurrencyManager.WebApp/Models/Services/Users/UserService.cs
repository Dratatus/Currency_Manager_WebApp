using CurrencyManager.Data.Entities;
using CurrencyManager.Data.Repositories;
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

        public async Task<User> RegisterAsync(User newUser)
        {
            // todo: walidacja danych

            var userToRegister = await _repositoryBase.AddAsync(newUser);

            return userToRegister;
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            var users = await _repositoryBase.GetAllAsync();
            return users;
        }
    }
}
