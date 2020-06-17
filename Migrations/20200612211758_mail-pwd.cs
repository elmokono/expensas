using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpensasAbbinatura.Migrations
{
    public partial class mailpwd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Persons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Persons");
        }
    }
}
