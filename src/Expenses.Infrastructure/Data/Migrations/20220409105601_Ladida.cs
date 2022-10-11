using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Expenses.Infrastructure.Data.Migrations
{
    public partial class Ladida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Iban = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: false),
                    Type = table.Column<ushort>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Iban);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subcategories",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryId = table.Column<uint>(type: "INTEGER", nullable: false),
                    CategoryDtoId = table.Column<uint>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subcategories_Categories_CategoryDtoId",
                        column: x => x.CategoryDtoId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FixedTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CounterParty = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    TransactionIntervalId = table.Column<uint>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TransactionDirectionId = table.Column<uint>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<uint>(type: "INTEGER", nullable: true),
                    SubcategoryId = table.Column<uint>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FixedTransactions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FixedTransactions_Subcategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    MyIban = table.Column<string>(type: "TEXT", nullable: true),
                    CounterIban = table.Column<string>(type: "TEXT", nullable: true),
                    Direction = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Method = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryId = table.Column<uint>(type: "INTEGER", nullable: true),
                    SubcategoryId = table.Column<uint>(type: "INTEGER", nullable: true),
                    IsProcessed = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccountDtoIban = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountDtoIban",
                        column: x => x.AccountDtoIban,
                        principalTable: "Accounts",
                        principalColumn: "Iban",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Subcategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1u, "Overig" });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "Id", "CategoryDtoId", "CategoryId", "Name" },
                values: new object[] { 1u, null, 1u, "Overig" });

            migrationBuilder.CreateIndex(
                name: "IX_FixedTransactions_CategoryId",
                table: "FixedTransactions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedTransactions_SubcategoryId",
                table: "FixedTransactions",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_CategoryDtoId",
                table: "Subcategories",
                column: "CategoryDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountDtoIban",
                table: "Transactions",
                column: "AccountDtoIban");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryId",
                table: "Transactions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SubcategoryId",
                table: "Transactions",
                column: "SubcategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FixedTransactions");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Subcategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
