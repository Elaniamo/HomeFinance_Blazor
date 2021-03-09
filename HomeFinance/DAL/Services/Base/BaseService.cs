using HomeFinance.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace HomeFinance.Services.Base
{
    public class BaseService
    {
        private readonly MyDbContext _context;

        public BaseService(MyDbContext context)
        {
            _context = context;
        }

        public bool TransactionsByСategoryExists(int id)
        {
            return _context.Transactions.Any(t => t.CategoryId == id);
        }

        public bool TypeMoneyCategoryExists(int id)
        {
            return _context.TypeMoneyCategories.Any(e => e.ID == id);
        }
        public bool MoneyCategoryExists(int id)
        {
            return _context.MoneyCategories.Any(e => e.ID == id);
        }
    }
}
