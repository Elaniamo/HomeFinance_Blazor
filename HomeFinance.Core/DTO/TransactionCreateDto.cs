using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace HomeFinance.DTO
{
    public class TransactionCreateDto
    {
        [BindingBehavior(BindingBehavior.Required)]
        public string Description { get; set; }
        [BindingBehavior(BindingBehavior.Required)]
        [Required]
        public int Amount { get; set; }
        [BindingBehavior(BindingBehavior.Required)]
        [Required]
        public int CategoryId { get; set; }
    }
}
