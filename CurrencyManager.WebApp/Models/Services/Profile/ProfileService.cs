namespace CurrencyManager.WebApp.Models.Services.Profile
{
    public class ProfileService : IProfileService
    {
        public bool CheckUserPremiumChanges(string password)
        {
            if (password == "1qazXSW@#premium")
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
