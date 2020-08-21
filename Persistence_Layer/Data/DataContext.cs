using Microsoft.EntityFrameworkCore;
using Persistence_Layer.Models;

namespace Persistence_Layer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<UserHistory> UserHistories { get; set; }
        public DbSet<AccountHistory> AccountHistories { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasKey(t => new { t.UserId, t.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.UserRole)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(pt => pt.Role)
                .WithMany(t => t.UserRole)
                .HasForeignKey(pt => pt.RoleId);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Description = "Admin" },
                new Role { Id = 2, Description = "User" },
                new Role { Id = 3, Description = "Viewer" }
            );

            modelBuilder.Entity<Business>().HasData(
                new Business { Id = 1, Address1 = "Address 1", Address2 = "Address 2", Name = "Business Name", State = "zz", ZipCode = "zzzzz" }
            );

            modelBuilder.Entity<Group>().HasData(
                new Group { Id = 1, Description = "External Group" },
                new Group { Id = 2, Description = "Internal Group" },
                new Group { Id = 3, Description = "Other Group" }
            );

            modelBuilder.Entity<Menu>().HasData(
                new Menu { Id = 1, Title = "Home", SortId = 1, MainMenuId = 0, Link = "home", UserRoles = "1,2,3" },
                new Menu { Id = 2, Title = "Account", SortId = 2, MainMenuId = 0, Link = "account", UserRoles = "1,2,3" },
                new Menu { Id = 3, Title = "Transaction", SortId = 3, MainMenuId = 0, Link = "transaction", UserRoles = "1,2,3" },
                new Menu { Id = 4, Title = "Reports", SortId = 4, MainMenuId = 0, Link = "report", UserRoles = "1,2,3" },
                new Menu { Id = 5, Title = "Code System", SortId = 5, MainMenuId = 0, Link = "code", UserRoles = "1" },
                new Menu { Id = 6, Title = "Setting", SortId = 6, MainMenuId = 0, Link = "setting", UserRoles = "1" },
                new Menu { Id = 7, Title = "Tools", SortId = 7, MainMenuId = 0, Link = "tool", UserRoles = "1" },
                new Menu { Id = 8, Title = "Menu", SortId = 1, MainMenuId = 5, Link = "menu", UserRoles = "1" },
                new Menu { Id = 9, Title = "Role", SortId = 1, MainMenuId = 6, Link = "role", UserRoles = "1" },
                new Menu { Id = 10, Title = "User", SortId = 2, MainMenuId = 6, Link = "user", UserRoles = "1" }
            );

            modelBuilder.Entity<Relationship>().HasData(
                new Relationship
                {
                    Id = 1,
                    Description = "father – somebody’s male parent"
                },

                new Relationship
                {
                    Id = 2,
                    Description = "mother – somebody’s female parent"
                },

                new Relationship
                {
                    Id = 3,
                    Description = "parent – somebody’s father or mother"
                },

                new Relationship
                {
                    Id = 4,
                    Description = "son – somebody’s male child"
                },

                new Relationship
                {
                    Id = 5,
                    Description = "daughter – somebody’s female child"
                },

                new Relationship
                {
                    Id = 6,
                    Description = "husband – the man who a woman is married to"
                },

                new Relationship
                {
                    Id = 7,
                    Description = "wife – the woman who a man is married to"
                },

                new Relationship
                {
                    Id = 8,
                    Description = "spouse – somebody married to another person; husband or wife"
                },
                new Relationship
                {
                    Id = 9,
                    Description = "brother – a boy or man who has the same parents as another person"
                },

                new Relationship
                {
                    Id = 10,
                    Description = "sister – a girl or woman who has the same parents as another person"
                },

                new Relationship
                {
                    Id = 11,
                    Description = "sibling – a brother or sister"
                },

                new Relationship
                {
                    Id = 12,
                    Description = "elder brother/ sister – a brother/ sister who is older than you"
                },

                new Relationship
                {
                    Id = 13,
                    Description = "younger brother / sister – brother / sister who is younger than you"
                },

                new Relationship
                {
                    Id = 14,
                    Description = "grandfather – somebody’s parent’s father"
                },

                new Relationship
                {
                    Id = 15,
                    Description = "grandmother – somebody’s parent’s mother"
                },

                new Relationship
                {
                    Id = 16,
                    Description = "Other"
                });

            modelBuilder.Entity<AccountType>().HasData( 
                new AccountType { Id = 1, Description = "Normal Account Type", GroupId = 1, SortId = 1 },
                new AccountType { Id = 2, Description = "Cash Account Type", GroupId = 2, SortId = 2 },
                new AccountType { Id = 3, Description = "Bank Account Type", GroupId = 2, SortId = 3 },
                new AccountType { Id = 4, Description = "Income Account Type", GroupId = 2, SortId = 4 },
                new AccountType { Id = 5, Description = "Expense Account Type", GroupId = 2, SortId = 5 },
                new AccountType { Id = 6, Description = "Payable Account Type", GroupId = 2, SortId = 6 },
                new AccountType { Id = 7, Description = "Receivable Account Type", GroupId = 2, SortId = 7 },
                new AccountType { Id = 8, Description = "Assets Account Type", GroupId = 2, SortId = 8 },
                new AccountType { Id = 9, Description = "Liabilities Account Type", GroupId = 2, SortId = 9 },
                new AccountType { Id = 10, Description = "Other Account Type", GroupId = 3, SortId = 10 }
            );
        }
    }
}