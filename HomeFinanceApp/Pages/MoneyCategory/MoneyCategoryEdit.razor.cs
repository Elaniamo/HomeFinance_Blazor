using HomeFinance.DTO;
using HomeFinanceApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace HomeFinanceApp.Pages.MoneyCategory
{
    public class MoneyCategoryEditPage : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        [Inject]
        public IHomeFinanceAPI HomeFinanceAPI { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }

        protected MoneyCategoryUpadateDto Mc = new MoneyCategoryUpadateDto();

        protected async Task SaveMoneyCategory()
        {
            await HomeFinanceAPI.UpadateMoneyCategoryAsync(Mc);
            NavigationManager.NavigateTo("moneycategory");
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/moneycategory");
        }

        protected override async Task OnInitializedAsync()
        {
            Mc = await HomeFinanceAPI.GetMoneyCategoryByID(Convert.ToInt32(Id));

        }
    }
}
