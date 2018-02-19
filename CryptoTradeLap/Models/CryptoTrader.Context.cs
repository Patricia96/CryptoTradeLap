
namespace CryptoTradeLap.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class CryptoTraderEntities : DbContext
    {
        public CryptoTraderEntities()
            : base("name=CryptoTraderEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        internal object GetUserVMs()
        {
            throw new NotImplementedException();
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Balance> Balance { get; set; }
        public virtual DbSet<BankAccount> BankAccount { get; set; }
        public virtual DbSet<BankTransferHistory> BankTransferHistory { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Ticker> Ticker { get; set; }
        public virtual DbSet<TradeHistory> TradeHistory { get; set; }
        public virtual DbSet<Upload> Upload { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}

