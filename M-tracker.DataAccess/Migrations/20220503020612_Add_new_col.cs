using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace M_tracker.DataAccess.Migrations
{
    public partial class Add_new_col : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsProceed",
                table: "GroupTotals",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsProceed",
                table: "GroupTotals");
        }
    }
}
