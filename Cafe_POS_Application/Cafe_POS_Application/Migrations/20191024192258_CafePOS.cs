using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Cafe_POS_Application.Migrations
{
    public partial class CafePOS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpID = table.Column<int>(maxLength: 30, nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    EmpName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ContactInfo = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    HireDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpID);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    FoodCode = table.Column<string>(maxLength: 30, nullable: false),
                    DishName = table.Column<string>(nullable: true),
                    Drinks = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.FoodCode);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    FoodCode = table.Column<string>(maxLength: 30, nullable: false),
                    DishName = table.Column<string>(nullable: true),
                    Drinks = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.FoodCode);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderNo = table.Column<int>(maxLength: 30, nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    EmpName = table.Column<string>(nullable: false),
                    FoodCode = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    TableNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderNo);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    TransactionID = table.Column<Guid>(maxLength: 30, nullable: false),
                    OrderNo = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    OrderDetails = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Balance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.TransactionID);
                });

            migrationBuilder.CreateTable(
                name: "Table",
                columns: table => new
                {
                    TableNo = table.Column<int>(maxLength: 30, nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Status = table.Column<string>(nullable: true),
                    Reservation = table.Column<string>(nullable: true),
                    ReservationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => x.TableNo);
                });

            migrationBuilder.CreateTable(
                name: "PaymentsLine",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TransactionLineId = table.Column<Guid>(nullable: false),
                    TransactionID = table.Column<Guid>(nullable: false),
                    MenuFoodCode = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Balance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentsLine", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PaymentsLine_Menus_MenuFoodCode",
                        column: x => x.MenuFoodCode,
                        principalTable: "Menus",
                        principalColumn: "FoodCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentsLine_Payments_TransactionID",
                        column: x => x.TransactionID,
                        principalTable: "Payments",
                        principalColumn: "TransactionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<Guid>(maxLength: 30, nullable: false),
                    OrderNo = table.Column<int>(nullable: false),
                    OrderDetails = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    TableNo = table.Column<int>(nullable: false),
                    EmpName = table.Column<string>(nullable: true),
                    EmployeeEmpID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transactions_Employees_EmployeeEmpID",
                        column: x => x.EmployeeEmpID,
                        principalTable: "Employees",
                        principalColumn: "EmpID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Table_TableNo",
                        column: x => x.TableNo,
                        principalTable: "Table",
                        principalColumn: "TableNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentsLine_MenuFoodCode",
                table: "PaymentsLine",
                column: "MenuFoodCode");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentsLine_TransactionID",
                table: "PaymentsLine",
                column: "TransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_EmployeeEmpID",
                table: "Transactions",
                column: "EmployeeEmpID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TableNo",
                table: "Transactions",
                column: "TableNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PaymentsLine");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Table");
        }
    }
}
