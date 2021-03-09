using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeFinance.Model
{
    public class TypeMoneyCategory
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(11)]
        public string Type { get; set; }

        public virtual ICollection<MoneyCategory> MoneyCategory { get; set; }
    }
}
