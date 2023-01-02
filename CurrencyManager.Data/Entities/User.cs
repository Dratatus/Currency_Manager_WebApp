namespace CurrencyManager.Data.Entities
{
    public class User : EntityBase
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string Balance { get; set; }
    }
}
