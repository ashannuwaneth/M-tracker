using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace M_tracker.DataAccess.Migrations
{
    public partial class Add_new_col_new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "GroupExpensesManages");

            migrationBuilder.RenameColumn(
                name: "DateTo",
                table: "GroupExpensesManages",
                newName: "ExpensesDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpensesDate",
                table: "GroupExpensesManages",
                newName: "DateTo");

            migrationBuilder.AddColumn<string>(
                name: "DateFrom",
                table: "GroupExpensesManages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
