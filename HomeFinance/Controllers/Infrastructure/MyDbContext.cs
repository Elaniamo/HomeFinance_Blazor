using HomeFinance.Model;
using Microsoft.EntityFrameworkCore;

namespace HomeFinance.Infrastructure
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<MoneyCategory> MoneyCategories { get; set; }
        public DbSet<TypeMoneyCategory> TypeMoneyCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Transaction>().HasOne(p => p.MoneyCategory).WithMany(f => f.Transaction).HasForeignKey(p => p.CategoryId).IsRequired();
            modelBuilder.Entity<MoneyCategory>().HasOne(p => p.TypeMoneyCategory).WithMany(f => f.MoneyCategory).HasForeignKey(p => p.TypeId).IsRequired();
        }
    }
}
