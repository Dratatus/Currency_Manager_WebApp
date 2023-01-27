using System.Collections.Generic;

namespace CurrencyManager.Data.Entities
{
    public class User : EntityBase
    {
        public virtual Passes Passes { get; set; }
        public virtual int PassesId { get; set; }

        public bool IsPremium { get; set; }

        public virtual PersonalInfo PersonalInfo { get; set; }
        public virtual int  PersonalInfoId { get; set; }

        public virtual ICollection<ExchangeRateHistory> ExchangeRateHistory { get; set; }

        public virtual int ExchangeRateHistoryId { get; set; }

        public User()
        {
            ExchangeRateHistory = new HashSet<ExchangeRateHistory>();
        }
    }
}
