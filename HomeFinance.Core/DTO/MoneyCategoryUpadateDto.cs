using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HomeFinance.DTO
{
    public class MoneyCategoryUpadateDto
    {
        [BindingBehavior(BindingBehavior.Required)]
        public int Id { get; set; }
        [BindingBehavior(BindingBehavior.Required)]
        public int TypeId { get; set; }
        [BindingBehavior(BindingBehavior.Required)]
        public string Description { get; set; }
    }
}
