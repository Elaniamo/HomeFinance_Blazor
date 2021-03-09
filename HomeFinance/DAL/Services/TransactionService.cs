using AutoMapper;
using HomeFinance.DTO;
using HomeFinance.Infrastructure;
using HomeFinance.Model;
using HomeFinance.Services.Base;
using HomeFinance.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HomeFinance.Services
{
    public class TransactionService : BaseService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public TransactionService(MyDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TurnoverFullViewModel> GetTurnoverOnDateAsync(PeriodDto periodDto)
        {
            TurnoverFullViewModel TurnoverFull = new TurnoverFullViewModel();
            TurnoverFull.StartDate = periodDto.StartDate;
            TurnoverFull.EndDate = periodDto.EndDate;
            TurnoverFull.All_Plus_Sum = await GetPlus_SumOnDateAsync(periodDto);
            TurnoverFull.All_Minus_Sum = await GetMinus_SumOnDateAsync(periodDto);

            var q = (from tr in _context.Transactions
                     from cat in _context.MoneyCategories
                     where tr.CategoryId == cat.ID
                     where tr.Date >= periodDto.StartDate && tr.Date <= periodDto.EndDate.AddDays(1) //.AddDays(1) as EndDay
                     select new { Category = cat.Description, tr.Date, tr.Amount, tr.Description });
            TurnoverFull.Transactions = await q.Select(x => new TurnoverViewModel { Category = x.Category, Date = x.Date, Amount = x.Amount, Description = x.Description }).ToListAsync();

            return TurnoverFull;
        }
        public async Task<BalanceOnDateViewModel> GetBalanceOnDateAsync(DateTime BalanceOnDate)
        {
            BalanceOnDateViewModel Balance = new BalanceOnDateViewModel();
            PeriodDto period = new PeriodDto { StartDate = BalanceOnDate, EndDate = BalanceOnDate.AddDays(1) };

            if (BalanceOnDate == new DateTime())
                BalanceOnDate = DateTime.Now;

            Balance.Date = BalanceOnDate;
            Balance.ReceiptAmount = await GetPlus_SumOnDateAsync(period);
            Balance.ExpenseAmount = await GetMinus_SumOnDateAsync(period);
            Balance.Total = await GetTotalOnDateAsync(period.EndDate);
            return Balance;
        }
        public async Task<TransactionViewModel> CreateTransactionAsync(TransactionCreateDto tm)
        {
            Transaction newTransaction = new Transaction()
            {
                CategoryId = tm.CategoryId,
                Amount = GetAmountAccordingType(tm.Amount, tm.CategoryId),
                Description = tm.Description,
                MoneyCategory = _context.MoneyCategories.Find(tm.CategoryId)
            };

            _context.Transactions.Add(newTransaction);

            return await GetSavedModelAsync(newTransaction);
        }
        private async Task<int> GetTotalOnDateAsync(DateTime Date)
        {
            return await _context.Transactions.Where(s => s.Date <= Date).SumAsync(a => a.Amount);
        }
        private async Task<int> GetMinus_SumOnDateAsync(PeriodDto periodDto)
        {
            return await _context.Transactions.Where(s => s.Amount < 0
                && s.Date >= periodDto.StartDate && s.Date <= periodDto.EndDate).SumAsync(a => a.Amount);
        }
        private async Task<int> GetPlus_SumOnDateAsync(PeriodDto periodDto)
        {
            return await _context.Transactions.Where(s => s.Amount > 0
                && s.Date >= periodDto.StartDate && s.Date <= periodDto.EndDate).SumAsync(a => a.Amount);
        }
        private int GetAmountAccordingType(int Amount, int CategoryId)
        {
            var CurrCategory = _context.MoneyCategories.Find(CategoryId);
            var CurrType = _context.TypeMoneyCategories.Find(CurrCategory.TypeId);
            var CurrAmount = (CurrType.ID.Equals(1) ? 1 : -1) * Amount;
            return CurrAmount;
        }
        private TransactionViewModel GetMappedModel(Transaction Transaction)
        {
            return _mapper.Map<Transaction, TransactionViewModel>(Transaction);
        }
        private async Task<TransactionViewModel> GetSavedModelAsync(Transaction Transaction)
        {
            try
            {
                await this._context.SaveChangesAsync();
                return GetMappedModel(Transaction);
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
        }
    }
}
