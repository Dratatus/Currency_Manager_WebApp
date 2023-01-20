using CurrencyManager.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyManager.WebApp.Services.Users
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();

        Task<bool> LoginAsync(string emailAddress, string password);

        Task<bool> RegisterAsync(string emailAddress, string password);
    }
}
