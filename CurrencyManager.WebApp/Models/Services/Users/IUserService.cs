using CurrencyManager.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyManager.WebApp.Services.Users
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<bool> UserExists(string emailAddress);
        Task<bool> LoginAsync(string emailAddress, string password);

        Task RegisterAsync(string emailAddress, string password);
    }
}
