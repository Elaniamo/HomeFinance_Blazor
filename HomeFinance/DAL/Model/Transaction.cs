using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeFinance.Model
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public virtual int CategoryId { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public MoneyCategory MoneyCategory { get; set; }

        public Transaction()
        {
            Date = DateTime.Now;
        }
    }
}
