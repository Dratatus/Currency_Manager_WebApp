using CurrencyManager.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyManager.WebApp.Services.Users
{
    public interface IUserService
    {
        Task<bool> UserExists(string emailAddress);
        Task<bool> LoginAsync(Passes passes);

        Task RegisterAsync(string email, string password);
        bool IsUserLogged();
        void Logout();

        public User LoggedUser { get;}

    }
}
