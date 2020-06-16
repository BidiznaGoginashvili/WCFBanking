using System.Data.Entity;
using Banking.Domain.CityManagement;
using Banking.Domain.LoanManagement;
using Banking.Domain.RoleManagement;
using Banking.Domain.UserManagement;
using Banking.Domain.CountryManagement;
using Banking.Domain.DepositManagement;

namespace Banking.Infrastructure.DataBase
{
    public class BankingContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Loan> Loan { get; set; }
        public DbSet<Deposit> Deposit { get; set; }

        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }

        public BankingContext() : base(@"Server=DESKTOP-KCSUK0G\BIDZINASQL; Database=BankingManagement; Trusted_Connection=True")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
              .HasMany(country => country.Cities)
              .WithOptional(city => city.Country);

            modelBuilder.Entity<User>()
             .HasMany(user => user.Loans)
             .WithOptional(loan => loan.User);

            modelBuilder.Entity<User>()
            .HasMany(user => user.Deposits)
            .WithOptional(deposit => deposit.User);
        }
    }
}
