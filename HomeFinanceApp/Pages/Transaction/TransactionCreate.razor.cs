using HomeFinance.DTO;
using HomeFinance.ViewModels;
using HomeFinanceApp.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeFinanceApp.Pages.Transaction
{
    public class TransactionCreatePage : ComponentBase
    {
        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Inject]
        public IHomeFinanceAPI HomeFinanceAPI { get; set; }

        protected TransactionCreateDto tm = new TransactionCreateDto();
        protected IEnumerable<MoneyCategoryViewModel> McList;

        protected async Task CreateTransaction()
        {
            await HomeFinanceAPI.CreateTransactionAsync(tm);
            NavigationManager.NavigateTo("/");
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/");
        }

        protected override async Task OnInitializedAsync()
        {
            McList = await HomeFinanceAPI.GetAllCategoriesAsync();
        }
    }
}
