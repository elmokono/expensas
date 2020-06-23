using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ExpensasAbbinatura.Migrations
{
    public partial class addbuilding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildingID",
                table: "Persons",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    BuildingID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.BuildingID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_BuildingID",
                table: "Persons",
                column: "BuildingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Buildings_BuildingID",
                table: "Persons",
                column: "BuildingID",
                principalTable: "Buildings",
                principalColumn: "BuildingID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Buildings_BuildingID",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropIndex(
                name: "IX_Persons_BuildingID",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "BuildingID",
                table: "Persons");
        }
    }
}
