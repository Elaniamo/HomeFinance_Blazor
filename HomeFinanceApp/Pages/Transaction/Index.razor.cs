using HomeFinance.ViewModels;
using HomeFinanceApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace HomeFinanceApp.Pages
{
    public class HomePage : ComponentBase
    {
        [Inject]
        public IHomeFinanceAPI HomeFinanceAPI { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }

        public string Time { get; set; }
        public BalanceOnDateViewModel Balance { get; set; }
        public TurnoverFullViewModel Turnover { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        protected void AddNewTransaction()
        {
            NavigationManager.NavigateTo("TransactionCreate");
        }

        public async Task FilterStartDateChangedAsync(ChangeEventArgs args)
        {
            DateTime firstDate = DateTime.Parse(args.Value.ToString());
            if (CheckPeriod(firstDate, EndDate))
            {
                StartDate = firstDate;
                await GetTurnover();
            }
        }

        public async Task FilterEndDateChangedAsync(ChangeEventArgs args)
        {
            DateTime secondDate = DateTime.Parse(args.Value.ToString());
            if (CheckPeriod(StartDate, secondDate))
            {
                EndDate = DateTime.Parse(args.Value.ToString());
                await GetTurnover();
            }
        }

        bool CheckPeriod(DateTime firstDate, DateTime secondDate)
        {
            if (firstDate.Day <= secondDate.Day)
                return true;

            NavigationManager.NavigateTo("/ModalWindow");
            return false;
        }

        public async Task GetTurnover()
        {
            Turnover = await HomeFinanceAPI.GetTurnoverOnDateAsync(
            new HomeFinance.DTO.PeriodDto { StartDate = StartDate, EndDate = EndDate });
        }
        protected override async Task OnInitializedAsync()
        {
            EndDate = DateTime.Now.AddHours(1);
            StartDate = EndDate.AddMonths(-1);

            Balance = await HomeFinanceAPI.GetBalanceOnDateAsync(EndDate);
            await GetTurnover();
        }

    }
}
