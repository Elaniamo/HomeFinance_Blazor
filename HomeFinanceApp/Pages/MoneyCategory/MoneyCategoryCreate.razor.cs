using HomeFinance.DTO;
using HomeFinanceApp.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace HomeFinanceApp.Pages.MoneyCategory
{
    public class MoneyCategoryCreatePage : ComponentBase
    {
        [Inject]
        public IHomeFinanceAPI HomeFinanceAPI { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }

        protected MoneyCategoryCreateDto mc = new MoneyCategoryCreateDto();

        protected async Task CreateMoneyCategory()
        {
            await HomeFinanceAPI.CreateMoneyCategoryAsync(mc);
            NavigationManager.NavigateTo("moneycategory");
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/moneycategory");
        }
    }
}
