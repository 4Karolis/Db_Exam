using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Db_Exam.Migrations
{
    public partial class Updated_Lecture_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Lectures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Lectures");
        }
    }
}
