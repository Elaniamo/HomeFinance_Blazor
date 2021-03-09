using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HomeFinance.DTO
{
    public class MoneyCategoryCreateDto
    {
        [BindingBehavior(BindingBehavior.Required)]
        public string NewName { get; set; }
        [BindingBehavior(BindingBehavior.Required)]
        public int TypeCategoryId { get; set; }
    }
}
