using CurrencyManager.Logic.Models;

namespace CurrencyManager.Data.Entities
{
    public class ExchangeRateHistory : EntityBase
    {
        public virtual int UserId { get; set; }

        public string OperationName { get; set; }
        // Kupowana waluta
        public string BoughtCurrency { get; set; }

        // Sprzedawana waluta
        public string SelledCurrency { get; set; }

        // Ilość
        public decimal Amount { get; set; }
    }
}
