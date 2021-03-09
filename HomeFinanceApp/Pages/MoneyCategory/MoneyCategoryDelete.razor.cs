using HomeFinance.DTO;
using HomeFinanceApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace HomeFinanceApp.Pages.MoneyCategory
{
    public class MoneyCategoryDeletePage : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        [Inject]
        public IHomeFinanceAPI HomeFinanceAPI { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }

        protected MoneyCategoryUpadateDto mc = new MoneyCategoryUpadateDto();

        protected string Title { get; set; }
        protected bool IsDisabled { get; set; }

        protected async Task DeleteMoneyCategory()
        {
            await HomeFinanceAPI.DeleteMoneyCategoryAsync(mc.Id);
            NavigationManager.NavigateTo("moneycategory");
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/moneycategory");
        }

        protected override async Task OnInitializedAsync()
        {
            if (await HomeFinanceAPI.CheckTransactionsByСategoryExists(Convert.ToInt32(Id)))
            {
                IsDisabled = true;
                Title = "Deletion is not possible, there are transactions in this category";
            }
            else
            {
                IsDisabled = false;
                Title = "Delete money category";
            }

            mc = await HomeFinanceAPI.GetMoneyCategoryByID(Convert.ToInt32(Id));

        }
    }
}
