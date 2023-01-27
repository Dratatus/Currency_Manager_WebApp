using CurrencyManager.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyManager.WebApp.Services.Users
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<bool> UserExists(string emailAddress);
        Task<bool> LoginAsync(Passes passes);

        Task RegisterAsync(string email, string password);
        bool IsUserLogged();
        public User LoggedUser { get;}

    }
}
