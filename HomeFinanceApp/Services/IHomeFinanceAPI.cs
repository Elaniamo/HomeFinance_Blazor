using HomeFinance.DTO;
using HomeFinance.ViewModels;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeFinanceApp.Services
{
    public interface IHomeFinanceAPI
    {
        [Get("/MoneyCategory")]
        Task<IEnumerable<MoneyCategoryViewModel>> GetAllCategoriesAsync();
        
        [Get("/MoneyCategory/id?")]
        Task<MoneyCategoryUpadateDto> GetMoneyCategoryByID(int id);
        
        [Post("/MoneyCategory")]
        Task<MoneyCategoryViewModel> CreateMoneyCategoryAsync(MoneyCategoryCreateDto mc);
        
        [Put("/MoneyCategory")]
        Task<MoneyCategoryViewModel> UpadateMoneyCategoryAsync(MoneyCategoryUpadateDto mc);
        
        [Delete("/MoneyCategory/id?")]
        Task<MoneyCategoryViewModel> DeleteMoneyCategoryAsync(int Id);

        [Get("/Transaction")]
        Task<BalanceOnDateViewModel> GetBalanceOnDateAsync(DateTime BalanceOnDate);

        [Get("/Transaction/periodDto?")]
        Task<TurnoverFullViewModel> GetTurnoverOnDateAsync(PeriodDto periodDto);

        [Post("/Transaction")]
        Task<TransactionViewModel> CreateTransactionAsync(TransactionCreateDto tm);

        [Get("/Transaction/Id?")]
        Task<bool> CheckTransactionsByСategoryExists(int СategoryId);
    }
}
