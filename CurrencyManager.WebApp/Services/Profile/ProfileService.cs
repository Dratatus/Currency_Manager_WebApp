namespace CurrencyManager.WebApp.Services.Profile
{
    public class ProfileService : IProfileService
    {
        public bool CheckUserPremiumChanges(string password)
        {
            if (password == "1qazXSW@#admin")
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
