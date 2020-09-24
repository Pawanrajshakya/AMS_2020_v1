using Microsoft.EntityFrameworkCore;
using Persistence.Models;
using Persistence_Layer.Models;
using System;

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
        public DbSet<TransactionCode> TransactionCodes { get; set; }
        public DbSet<TransactionTypeDetail> TransactionTypeDetails { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<UserHistory> UserHistories { get; set; }
        public DbSet<AccountHistory> AccountHistories { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<Control> Controls { get; set; }
        public DbSet<Image> Images { get; set; }

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

            modelBuilder.Entity<User>().HasQueryFilter(x => x.IsVisible);
            modelBuilder.Entity<Role>().HasQueryFilter(x => x.IsVisible);
            modelBuilder.Entity<Menu>().HasQueryFilter(x => x.IsVisible);
            modelBuilder.Entity<Business>().HasQueryFilter(x => x.IsVisible);
            modelBuilder.Entity<Client>().HasQueryFilter(x => x.IsVisible);
            modelBuilder.Entity<AccountType>().HasQueryFilter(x => x.IsVisible);
            modelBuilder.Entity<Relationship>().HasQueryFilter(x => x.IsVisible);
            modelBuilder.Entity<Transaction>().HasQueryFilter(x => x.IsVisible);
            modelBuilder.Entity<TransactionType>().HasQueryFilter(x => x.IsVisible);
            modelBuilder.Entity<Group>().HasQueryFilter(x => x.IsVisible);
            modelBuilder.Entity<Account>().HasQueryFilter(x => x.IsVisible);
            modelBuilder.Entity<Image>().HasQueryFilter(x => x.IsVisible);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Description = "Admin", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now },
                new Role { Id = 2, Description = "User", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now },
                new Role { Id = 3, Description = "Viewer", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now }
            );

            modelBuilder.Entity<Business>().HasData(
                new Business { Id = 1, Address1 = "Address 1", Address2 = "Address 2", Name = "Your Business Name", State = "zz", ZipCode = "zzzzz", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now }
            );

            modelBuilder.Entity<Group>().HasData(
                new Group { Id = 1, Description = "External Group", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now },
                new Group { Id = 2, Description = "Internal Group", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now },
                new Group { Id = 3, Description = "Other Group", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now }
            );

            modelBuilder.Entity<Menu>().HasData(
                new Menu { Id = 1, Title = "Home", SortId = 1, MainMenuId = 0, Link = "home", UserRoles = "1,2,3", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now },
                new Menu { Id = 2, Title = "Account", SortId = 2, MainMenuId = 0, Link = "account", UserRoles = "1,2,3", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now },
                new Menu { Id = 3, Title = "Transaction", SortId = 3, MainMenuId = 0, Link = "transaction", UserRoles = "1,2,3", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now },
                new Menu { Id = 4, Title = "Reports", SortId = 4, MainMenuId = 0, Link = "report", UserRoles = "1,2,3", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now },
                new Menu { Id = 5, Title = "Code System", SortId = 5, MainMenuId = 0, Link = "code", UserRoles = "1", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now },
                new Menu { Id = 6, Title = "Setting", SortId = 6, MainMenuId = 0, Link = "setting", UserRoles = "1", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now },
                new Menu { Id = 7, Title = "Tools", SortId = 7, MainMenuId = 0, Link = "tool", UserRoles = "1", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now },
                new Menu { Id = 8, Title = "Menu", SortId = 1, MainMenuId = 5, Link = "menu", UserRoles = "1", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now },
                new Menu { Id = 9, Title = "Role", SortId = 1, MainMenuId = 6, Link = "role", UserRoles = "1", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now },
                new Menu { Id = 10, Title = "User", SortId = 2, MainMenuId = 6, Link = "user", UserRoles = "1", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now }
            );

            modelBuilder.Entity<Relationship>().HasData(
                new Relationship
                {
                    Id = 1,
                    Description = "~",
                    IsActive = true,
                    IsVisible = true,
                    CreatedDate = DateTime.Now
                },

                new Relationship
                {
                    Id = 2,
                    Description = "Mother",
                    IsActive = true,
                    IsVisible = true,
                    CreatedDate = DateTime.Now
                },

                new Relationship
                {
                    Id = 3,
                    Description = "Parent",
                    IsActive = true,
                    IsVisible = true,
                    CreatedDate = DateTime.Now
                },

                new Relationship
                {
                    Id = 4,
                    Description = "Son",
                    IsActive = true,
                    IsVisible = true,
                    CreatedDate = DateTime.Now
                },

                new Relationship
                {
                    Id = 5,
                    Description = "Daughter",
                    IsActive = true,
                    IsVisible = true,
                    CreatedDate = DateTime.Now
                },

                new Relationship
                {
                    Id = 6,
                    Description = "Husband",
                    IsActive = true,
                    IsVisible = true,
                    CreatedDate = DateTime.Now
                },

                new Relationship
                {
                    Id = 7,
                    Description = "Wife",
                    IsActive = true,
                    IsVisible = true,
                    CreatedDate = DateTime.Now
                },

                new Relationship
                {
                    Id = 8,
                    Description = "Spouse",
                    IsActive = true,
                    IsVisible = true,
                    CreatedDate = DateTime.Now
                },
                new Relationship
                {
                    Id = 9,
                    Description = "Brother",
                    IsActive = true,
                    IsVisible = true,
                    CreatedDate = DateTime.Now
                },

                new Relationship
                {
                    Id = 10,
                    Description = "Sister",
                    IsActive = true,
                    IsVisible = true,
                    CreatedDate = DateTime.Now
                },

                new Relationship
                {
                    Id = 11,
                    Description = "Sibling",
                    IsActive = true,
                    IsVisible = true,
                    CreatedDate = DateTime.Now
                },

                new Relationship
                {
                    Id = 12,
                    Description = "Elder brother/sister",
                    IsActive = true,
                    IsVisible = true,
                    CreatedDate = DateTime.Now
                },

                new Relationship
                {
                    Id = 13,
                    Description = "Younger brother/sister",
                    IsActive = true,
                    IsVisible = true,
                    CreatedDate = DateTime.Now
                },

                new Relationship
                {
                    Id = 14,
                    Description = "Grandfather",
                    IsActive = true,
                    IsVisible = true,
                    CreatedDate = DateTime.Now
                },

                new Relationship
                {
                    Id = 15,
                    Description = "Grandmother",
                    IsActive = true,
                    IsVisible = true,
                    CreatedDate = DateTime.Now
                },

                new Relationship
                {
                    Id = 16,
                    Description = "Father",
                    IsActive = true,
                    IsVisible = true,
                    CreatedDate = DateTime.Now

                },
                new Relationship
                {
                    Id = 17,
                    Description = "Other",
                    IsActive = true,
                    IsVisible = true,
                    CreatedDate = DateTime.Now
                });

            modelBuilder.Entity<AccountType>().HasData(
                new AccountType { Id = 1, Description = "Normal Account", GroupId = 1, SortId = 1, ShortName = "NA", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now },
                new AccountType { Id = 2, Description = "Cash Account", GroupId = 2, SortId = 2, ShortName = "CA", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now },
                new AccountType { Id = 3, Description = "Bank Account", GroupId = 2, SortId = 3, ShortName = "BA", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now },
                new AccountType { Id = 4, Description = "Income Account", GroupId = 2, SortId = 4, ShortName = "IA", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now },
                new AccountType { Id = 5, Description = "Expense Account", GroupId = 2, SortId = 5, ShortName = "EA", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now },
                new AccountType { Id = 6, Description = "Payable Account", GroupId = 2, SortId = 6, ShortName = "PA", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now },
                new AccountType { Id = 7, Description = "Receivable Account", GroupId = 2, SortId = 7, ShortName = "RA", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now },
                new AccountType { Id = 8, Description = "Assets Account", GroupId = 2, SortId = 8, ShortName = "AA", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now },
                new AccountType { Id = 9, Description = "Liabilities Account", GroupId = 2, SortId = 9, ShortName = "LA", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now },
                new AccountType { Id = 10, Description = "Other Account", GroupId = 3, SortId = 10, ShortName = "OA", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now }
            );

            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, BusinessId = 1, Name = "Internal Client", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now },
                new Client { Id = 2, BusinessId = 1, Name = "Default Client", IsActive = true, IsVisible = true, CreatedDate = DateTime.Now }
                );

            modelBuilder.Entity<Control>().HasData(
                new Control { Id = 1, BusinessId = 1, AccountNoLength = 20, CurrentDate = DateTime.Today, ReportFolderName = @"Reports\" }
                );

            modelBuilder.Entity<TransactionCode>().HasData(
                new TransactionCode { TranCode = 100, Description = "Credit (+)", IsDebit = false },
                new TransactionCode { TranCode = 200, Description = "Debit (-)", IsDebit = true }
                );
        }
    }
}