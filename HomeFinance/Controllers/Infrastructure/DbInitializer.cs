using HomeFinance.Model;
using System;
using System.Linq;

namespace HomeFinance.Infrastructure
{
    public static class DbInitializer
    {
        public static void Initialize(MyDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any type categories.
            if (context.TypeMoneyCategories.Any())
            {
                return;   // DB has been seeded
            }

            context.TypeMoneyCategories.Add(new TypeMoneyCategory { Type = "Income"});
            context.TypeMoneyCategories.Add(new TypeMoneyCategory { Type = "Consumption" });
            
            context.SaveChanges();

            var category = new MoneyCategory[]
            {
                new MoneyCategory {Description = "Food", TypeId = 2},
                new MoneyCategory {Description = "Restaurant", TypeId = 2},
                new MoneyCategory {Description = "Home", TypeId = 2},
                new MoneyCategory {Description = "Car", TypeId = 2},
                new MoneyCategory {Description = "Fun", TypeId = 2},
                new MoneyCategory {Description = "Bills", TypeId = 2},
                new MoneyCategory {Description = "Loan", TypeId = 2},
                new MoneyCategory {Description = "Salary", TypeId = 1},
                new MoneyCategory {Description = "Dividents", TypeId = 1},
                new MoneyCategory {Description = "Clothes", TypeId = 2},
                new MoneyCategory {Description = "Vacation", TypeId = 2},
                new MoneyCategory {Description = "Public Transport", TypeId = 2},
                new MoneyCategory {Description = "Health", TypeId = 2},
                new MoneyCategory {Description = "Gift", TypeId = 2},
                new MoneyCategory {Description = "Culture", TypeId = 2},
                new MoneyCategory {Description = "Other", TypeId = 2}
            };

            foreach (MoneyCategory c in category)
                context.MoneyCategories.Add(c);

            context.SaveChanges();

            var Transactions = new Transaction[]
            {
                new Transaction {Date = DateTime.Now.AddDays(-1), CategoryId = 9, Amount = 500000, Description = "Other dividents" , MoneyCategory = context.MoneyCategories.Find(9)},
                new Transaction {Date = DateTime.Now, CategoryId = 13, Amount = -45, Description = "Purchase of season tickets" , MoneyCategory = context.MoneyCategories.Find(13)},
                new Transaction {Date = DateTime.Now, CategoryId = 4, Amount = -45, Description = "Purchased a car" , MoneyCategory = context.MoneyCategories.Find(13)},
                new Transaction {Date = DateTime.Now, CategoryId = 4, Amount = -150000, Description = "Tesla purchase" , MoneyCategory = context.MoneyCategories.Find(13)},
                new Transaction {Date = DateTime.Now, CategoryId = 4, Amount = -300, Description = "Dodge Maintenance" , MoneyCategory = context.MoneyCategories.Find(13)}
            };

            foreach (Transaction t in Transactions)
                context.Transactions.Add(t);

            context.SaveChanges();
        }
    }
}
