using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gproject.Infrastruct.Migrations
{
    public partial class PathFIle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathSaved",
                table: "Attachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathSaved",
                table: "Attachments");
        }
    }
}
