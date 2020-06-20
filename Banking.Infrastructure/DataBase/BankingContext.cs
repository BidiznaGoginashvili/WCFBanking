using System.Data.Entity;
using Banking.Domain.LoanManagement;
using Banking.Domain.RoleManagement;
using Banking.Domain.UserManagement;
using Banking.Domain.BranchManagement;
using Banking.Domain.DepositManagement;

namespace Banking.Infrastructure.DataBase
{
    public class BankingContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Loan> Loan { get; set; }
        public DbSet<Deposit> Deposit { get; set; }
        public DbSet<Branch> Branches { get; set; }

        public BankingContext() : base(@"Server=DESKTOP-KCSUK0G\BIDZINASQL; Database=BankingManagement; Trusted_Connection=True")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
             .HasMany(user => user.Loans)
             .WithOptional(loan => loan.User);

            modelBuilder.Entity<Role>()
             .HasMany(role => role.Users)
             .WithOptional(user => user.Role);

            modelBuilder.Entity<Branch>()
            .HasMany(c => c.Users)
            .WithOptional(e => e.Branches);

            modelBuilder.Entity<User>()
            .HasMany(user => user.Deposits)
            .WithOptional(deposit => deposit.User);
        }
    }
}
