using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeScoreApp.Migrations
{
    public partial class collegeList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Colleges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Colleges");
        }
    }
}
