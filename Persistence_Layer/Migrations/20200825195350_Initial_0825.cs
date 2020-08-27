using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Initial_0825 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountNo = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Balance = table.Column<decimal>(nullable: false),
                    AccountTypeId = table.Column<int>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 255, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 255, nullable: true),
                    Phone = table.Column<string>(maxLength: 12, nullable: true),
                    Email = table.Column<string>(maxLength: 55, nullable: true),
                    Address1 = table.Column<string>(maxLength: 255, nullable: true),
                    Address2 = table.Column<string>(maxLength: 255, nullable: true),
                    State = table.Column<string>(maxLength: 2, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 20, nullable: true),
                    RelationshipId = table.Column<int>(nullable: false),
                    SortId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Address1 = table.Column<string>(maxLength: 255, nullable: true),
                    Address2 = table.Column<string>(maxLength: 255, nullable: true),
                    State = table.Column<string>(maxLength: 2, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 5, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Description = table.Column<string>(nullable: false),
                    SortId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Title = table.Column<string>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    IconName = table.Column<string>(nullable: true),
                    MainMenuId = table.Column<int>(nullable: false),
                    SortId = table.Column<int>(nullable: false),
                    UserRoles = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserActivities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    DateRequested = table.Column<DateTime>(nullable: false),
                    ControllerName = table.Column<string>(nullable: true),
                    ActionName = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    UserRole = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    PasswordChangedCount = table.Column<int>(nullable: false),
                    LastPasswordChangedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PasswordChangedCount = table.Column<int>(nullable: false),
                    LastPasswordChangedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    BusinessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Controls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessId = table.Column<int>(nullable: false),
                    CurrentDate = table.Column<DateTime>(nullable: false),
                    AccountNoLength = table.Column<int>(nullable: false),
                    ReportFolderName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Controls_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SortId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false),
                    ShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountTypes_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    AccountNo = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Balance = table.Column<decimal>(nullable: false),
                    AccountTypeId = table.Column<int>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 255, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 255, nullable: true),
                    Phone = table.Column<string>(maxLength: 12, nullable: true),
                    Email = table.Column<string>(maxLength: 55, nullable: true),
                    Address1 = table.Column<string>(maxLength: 255, nullable: true),
                    Address2 = table.Column<string>(maxLength: 255, nullable: true),
                    State = table.Column<string>(maxLength: 2, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 20, nullable: true),
                    RelationshipId = table.Column<int>(nullable: false),
                    SortId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Account_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Account_Relationships_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "Relationships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AccountId = table.Column<int>(nullable: false),
                    ShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionTypes_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Description1 = table.Column<string>(maxLength: 255, nullable: true),
                    Description2 = table.Column<string>(maxLength: 255, nullable: true),
                    TransactionTypeId = table.Column<int>(nullable: false),
                    AccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionTypes_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Businesses",
                columns: new[] { "Id", "Address1", "Address2", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "Name", "State", "ZipCode" },
                values: new object[] { 1, "Address 1", "Address 2", 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), null, true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "Your Business Name", "zz", "zzzzz" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "SortId" },
                values: new object[] { 1, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "External Group", true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), 0 });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "SortId" },
                values: new object[] { 2, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "Internal Group", true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), 0 });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "SortId" },
                values: new object[] { 3, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "Other Group", true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), 0 });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IconName", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "Link", "MainMenuId", "SortId", "Title", "UserRoles" },
                values: new object[] { 10, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), null, true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "user", 6, 2, "User", "1" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IconName", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "Link", "MainMenuId", "SortId", "Title", "UserRoles" },
                values: new object[] { 9, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), null, true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "role", 6, 1, "Role", "1" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IconName", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "Link", "MainMenuId", "SortId", "Title", "UserRoles" },
                values: new object[] { 8, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), null, true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "menu", 5, 1, "Menu", "1" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IconName", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "Link", "MainMenuId", "SortId", "Title", "UserRoles" },
                values: new object[] { 6, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), null, true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "setting", 0, 6, "Setting", "1" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IconName", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "Link", "MainMenuId", "SortId", "Title", "UserRoles" },
                values: new object[] { 7, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), null, true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "tool", 0, 7, "Tools", "1" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IconName", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "Link", "MainMenuId", "SortId", "Title", "UserRoles" },
                values: new object[] { 4, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), null, true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "report", 0, 4, "Reports", "1,2,3" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IconName", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "Link", "MainMenuId", "SortId", "Title", "UserRoles" },
                values: new object[] { 3, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), null, true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "transaction", 0, 3, "Transaction", "1,2,3" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IconName", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "Link", "MainMenuId", "SortId", "Title", "UserRoles" },
                values: new object[] { 2, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), null, true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "account", 0, 2, "Account", "1,2,3" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IconName", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "Link", "MainMenuId", "SortId", "Title", "UserRoles" },
                values: new object[] { 1, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), null, true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "home", 0, 1, "Home", "1,2,3" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IconName", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "Link", "MainMenuId", "SortId", "Title", "UserRoles" },
                values: new object[] { 5, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), null, true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "code", 0, 5, "Code System", "1" });

            migrationBuilder.InsertData(
                table: "Relationships",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { 11, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "sibling – a brother or sister", true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393) });

            migrationBuilder.InsertData(
                table: "Relationships",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { 17, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "Other", true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393) });

            migrationBuilder.InsertData(
                table: "Relationships",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { 16, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "father – somebody’s male parent", true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393) });

            migrationBuilder.InsertData(
                table: "Relationships",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { 15, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "grandmother – somebody’s parent’s mother", true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393) });

            migrationBuilder.InsertData(
                table: "Relationships",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { 14, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "grandfather – somebody’s parent’s father", true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393) });

            migrationBuilder.InsertData(
                table: "Relationships",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { 13, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "younger brother / sister – brother / sister who is younger than you", true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393) });

            migrationBuilder.InsertData(
                table: "Relationships",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { 12, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "elder brother/ sister – a brother/ sister who is older than you", true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393) });

            migrationBuilder.InsertData(
                table: "Relationships",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { 10, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "sister – a girl or woman who has the same parents as another person", true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393) });

            migrationBuilder.InsertData(
                table: "Relationships",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { 3, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "parent – somebody’s father or mother", true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393) });

            migrationBuilder.InsertData(
                table: "Relationships",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { 8, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "spouse – somebody married to another person; husband or wife", true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393) });

            migrationBuilder.InsertData(
                table: "Relationships",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { 7, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "wife – the woman who a man is married to", true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393) });

            migrationBuilder.InsertData(
                table: "Relationships",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { 6, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "husband – the man who a woman is married to", true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393) });

            migrationBuilder.InsertData(
                table: "Relationships",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { 5, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "daughter – somebody’s female child", true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393) });

            migrationBuilder.InsertData(
                table: "Relationships",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { 4, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "son – somebody’s male child", true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393) });

            migrationBuilder.InsertData(
                table: "Relationships",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { 2, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "mother – somebody’s female parent", true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393) });

            migrationBuilder.InsertData(
                table: "Relationships",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { 1, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "NA – Not Applicable", true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393) });

            migrationBuilder.InsertData(
                table: "Relationships",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { 9, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "brother – a boy or man who has the same parents as another person", true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { 2, 0, new DateTime(2020, 8, 25, 15, 53, 50, 257, DateTimeKind.Local).AddTicks(394), "User", true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 257, DateTimeKind.Local).AddTicks(394) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { 1, 0, new DateTime(2020, 8, 25, 15, 53, 50, 254, DateTimeKind.Local).AddTicks(401), "Admin", true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 256, DateTimeKind.Local).AddTicks(408) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { 3, 0, new DateTime(2020, 8, 25, 15, 53, 50, 257, DateTimeKind.Local).AddTicks(394), "Viewer", true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 257, DateTimeKind.Local).AddTicks(394) });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "GroupId", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "ShortName", "SortId" },
                values: new object[] { 1, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "Normal Account", 1, true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "NA", 1 });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "GroupId", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "ShortName", "SortId" },
                values: new object[] { 2, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "Cash Account", 2, true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "CA", 2 });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "GroupId", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "ShortName", "SortId" },
                values: new object[] { 3, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "Bank Account", 2, true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "BA", 3 });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "GroupId", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "ShortName", "SortId" },
                values: new object[] { 4, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "Income Account", 2, true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "IA", 4 });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "GroupId", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "ShortName", "SortId" },
                values: new object[] { 5, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "Expense Account", 2, true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "EA", 5 });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "GroupId", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "ShortName", "SortId" },
                values: new object[] { 6, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "Payable Account", 2, true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "PA", 6 });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "GroupId", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "ShortName", "SortId" },
                values: new object[] { 7, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "Receivable Account", 2, true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "RA", 7 });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "GroupId", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "ShortName", "SortId" },
                values: new object[] { 8, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "Assets Account", 2, true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "AA", 8 });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "GroupId", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "ShortName", "SortId" },
                values: new object[] { 9, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "Liabilities Account", 2, true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "LA", 9 });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "GroupId", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "ShortName", "SortId" },
                values: new object[] { 10, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "Other Account", 3, true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "OA", 10 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "BusinessId", "CreatedBy", "CreatedDate", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { 1, 1, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "Internal Client" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "BusinessId", "CreatedBy", "CreatedDate", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { 2, 1, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), true, true, 0, new DateTime(2020, 8, 25, 15, 53, 50, 258, DateTimeKind.Local).AddTicks(393), "Default Client" });

            migrationBuilder.InsertData(
                table: "Controls",
                columns: new[] { "Id", "AccountNoLength", "BusinessId", "CurrentDate", "ReportFolderName" },
                values: new object[] { 1, 20, 1, new DateTime(2020, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), "Reports\\" });

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountTypeId",
                table: "Account",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_ClientId",
                table: "Account",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_RelationshipId",
                table: "Account",
                column: "RelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypes_GroupId",
                table: "AccountTypes",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_BusinessId",
                table: "Clients",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Controls_BusinessId",
                table: "Controls",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionTypeId",
                table: "Transactions",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTypes_AccountId",
                table: "TransactionTypes",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountHistories");

            migrationBuilder.DropTable(
                name: "Controls");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "UserActivities");

            migrationBuilder.DropTable(
                name: "UserHistories");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "TransactionTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Relationships");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Businesses");
        }
    }
}
