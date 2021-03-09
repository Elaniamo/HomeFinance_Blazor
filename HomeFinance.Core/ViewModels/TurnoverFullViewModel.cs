using System;
using System.Collections.Generic;

namespace HomeFinance.ViewModels
{
    public class TurnoverFullViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int All_Plus_Sum { get; set; }
        public int All_Minus_Sum { get; set; }
        public List<TurnoverViewModel> Transactions { get; set; }
    }
}
