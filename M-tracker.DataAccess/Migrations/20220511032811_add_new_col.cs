using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace M_tracker.DataAccess.Migrations
{
    public partial class add_new_col : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    ExpensesDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ExpensesTypeId = table.Column<int>(type: "int", nullable: false),
                    IncomeMethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Expenses_ExpensesTypes_ExpensesTypeId",
                        column: x => x.ExpensesTypeId,
                        principalTable: "ExpensesTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_IncomeMethods_IncomeMethodId",
                        column: x => x.IncomeMethodId,
                        principalTable: "IncomeMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpensesTypeId",
                table: "Expenses",
                column: "ExpensesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_IncomeMethodId",
                table: "Expenses",
                column: "IncomeMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_UserId",
                table: "Expenses",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");
        }
    }
}
