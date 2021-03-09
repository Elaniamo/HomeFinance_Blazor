using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeFinance.Model
{
    public class MoneyCategory
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public virtual int TypeId { get; set; }

        [Required]
        [StringLength(25)]
        public string Description { get; set; }

        public virtual ICollection<Transaction> Transaction { get; set; }
        public TypeMoneyCategory TypeMoneyCategory { get; set; }
    }
}
