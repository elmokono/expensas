using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpensasAbbinatura.Migrations
{
    public partial class installstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusInstallmentStatusID",
                table: "Installments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InstallmentStatus",
                columns: table => new
                {
                    InstallmentStatusID = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallmentStatus", x => x.InstallmentStatusID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Installments_StatusInstallmentStatusID",
                table: "Installments",
                column: "StatusInstallmentStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Installments_InstallmentStatus_StatusInstallmentStatusID",
                table: "Installments",
                column: "StatusInstallmentStatusID",
                principalTable: "InstallmentStatus",
                principalColumn: "InstallmentStatusID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installments_InstallmentStatus_StatusInstallmentStatusID",
                table: "Installments");

            migrationBuilder.DropTable(
                name: "InstallmentStatus");

            migrationBuilder.DropIndex(
                name: "IX_Installments_StatusInstallmentStatusID",
                table: "Installments");

            migrationBuilder.DropColumn(
                name: "StatusInstallmentStatusID",
                table: "Installments");
        }
    }
}
