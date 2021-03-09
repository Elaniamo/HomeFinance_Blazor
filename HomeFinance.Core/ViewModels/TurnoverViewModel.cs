using System;

namespace HomeFinance.ViewModels
{
    public class TurnoverViewModel
    {
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
    }
}
