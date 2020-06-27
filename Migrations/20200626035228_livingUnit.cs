using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ExpensasAbbinatura.Migrations
{
    public partial class livingUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installments_Persons_PersonId",
                table: "Installments");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Buildings_BuildingId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_BuildingId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Installments_PersonId",
                table: "Installments");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Installments");

            migrationBuilder.AddColumn<int>(
                name: "LivingUnitId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LivingUnitId",
                table: "Installments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LivingUnits",
                columns: table => new
                {
                    LivingUnitId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    BuildingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivingUnits", x => x.LivingUnitId);
                    table.ForeignKey(
                        name: "FK_LivingUnits_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_LivingUnitId",
                table: "Persons",
                column: "LivingUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Installments_LivingUnitId",
                table: "Installments",
                column: "LivingUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_LivingUnits_BuildingId",
                table: "LivingUnits",
                column: "BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Installments_LivingUnits_LivingUnitId",
                table: "Installments",
                column: "LivingUnitId",
                principalTable: "LivingUnits",
                principalColumn: "LivingUnitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_LivingUnits_LivingUnitId",
                table: "Persons",
                column: "LivingUnitId",
                principalTable: "LivingUnits",
                principalColumn: "LivingUnitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installments_LivingUnits_LivingUnitId",
                table: "Installments");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_LivingUnits_LivingUnitId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "LivingUnits");

            migrationBuilder.DropIndex(
                name: "IX_Persons_LivingUnitId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Installments_LivingUnitId",
                table: "Installments");

            migrationBuilder.DropColumn(
                name: "LivingUnitId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "LivingUnitId",
                table: "Installments");

            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Installments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_BuildingId",
                table: "Persons",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Installments_PersonId",
                table: "Installments",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Installments_Persons_PersonId",
                table: "Installments",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Buildings_BuildingId",
                table: "Persons",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "BuildingId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
