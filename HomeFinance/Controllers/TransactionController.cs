using HomeFinance.DTO;
using HomeFinance.Services;
using HomeFinance.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HomeFinance.Controllers
{
    [Route("[controller]")]
    public class TransactionController : Controller
    {
        private readonly TransactionService _transaction;

        public TransactionController(TransactionService Transaction)
        {
            _transaction = Transaction;
        }

        //GET: api/Transaction?BalanceOnDate=
        [HttpGet]
        public async Task<BalanceOnDateViewModel> GetBalance([FromQuery] DateTime BalanceOnDate)
        {
            return await _transaction.GetBalanceOnDateAsync(BalanceOnDate);
        }
        //GET: api/Transaction/periodDto?StartDate=&EndDate=
        [HttpGet("periodDto")]
        public async Task<TurnoverFullViewModel> GetTurnover([FromQuery] PeriodDto periodDto)
        {
            return await _transaction.GetTurnoverOnDateAsync(periodDto);
        }
        [HttpGet("Id")]
        public bool CheckTransactionsByСategoryExists([FromQuery] int СategoryId)
        {
            return _transaction.TransactionsByСategoryExists(СategoryId);
        }
        [HttpPost]
        public async Task<ActionResult<TransactionViewModel>> PostTransaction([FromBody] TransactionCreateDto tm)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            if (!_transaction.MoneyCategoryExists(tm.CategoryId))
                return NotFound();

            var createdCategory = await _transaction.CreateTransactionAsync(tm);
            if (createdCategory == null)
                return BadRequest();

            return createdCategory;
        }
    }
}
