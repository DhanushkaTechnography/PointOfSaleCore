using System;

namespace PizzaCore.Entity.Audit
{
    public class AuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}