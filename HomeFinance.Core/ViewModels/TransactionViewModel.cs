using System;

namespace HomeFinance.ViewModels
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual int CategoryId { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
    }
}
