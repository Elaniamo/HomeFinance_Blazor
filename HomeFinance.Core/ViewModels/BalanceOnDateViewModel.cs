﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeFinance.ViewModels
{
    public class BalanceOnDateViewModel
    {
        public DateTime Date { get; set; }
        public int ReceiptAmount { get; set; }
        public int ExpenseAmount { get; set; }
        public int Total { get; set; }
    }
}
