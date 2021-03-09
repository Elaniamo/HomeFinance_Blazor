using HomeFinance.ViewModels;
using HomeFinanceApp.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeFinanceApp.Pages
{
    public class PageMoneyCategory : ComponentBase
    {
        [Inject]
        public IHomeFinanceAPI HomeFinanceAPI { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }

        public IEnumerable<MoneyCategoryViewModel> McList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await InitializeList();
        }

        async Task InitializeList()
        {
            McList = await HomeFinanceAPI.GetAllCategoriesAsync();
        }

        protected void AddMoneyCategory()
        {
            NavigationManager.NavigateTo("/MoneyCategoryCreate");
        }

        protected void Edit(int Id)
        {
            NavigationManager.NavigateTo("/MoneyCategoryEdit/" + Id);
        }

        protected void Delete(int Id)
        {
            NavigationManager.NavigateTo("/MoneyCategoryDelete/" + Id);
        }
    }
}
