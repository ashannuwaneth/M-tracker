using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace M_tracker.DataAccess.Migrations
{
    public partial class new_colum_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ExpensesTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ExpensesTypes");
        }
    }
}
