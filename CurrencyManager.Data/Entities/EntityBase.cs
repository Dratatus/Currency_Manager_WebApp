using System;

namespace CurrencyManager.Data.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }

        public EntityBase()
        {
            CreationDate = DateTime.Now;
        }
    }
}
