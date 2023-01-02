using CurrencyManager.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyManager.WebApp.Services.Users
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUser();

        Task<bool> LoginAsync(string emailAddress, string password);

        Task<User> RegisterAsync(User newUser);
    }
}
