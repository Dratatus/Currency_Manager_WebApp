namespace CurrencyManager.Data.Entities
{
    public class ExchangeRateHistory : EntityBase
    {
        public virtual int UserId { get; set; }

        public string OperationName { get; set; }
        // Kupowana waluta
        // Sprzedawana waluta
        // Ilość
    }
}
