using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpensasAbbinatura.Migrations
{
    public partial class @case : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concepts_ConceptTypes_ConceptTypeID",
                table: "Concepts");

            migrationBuilder.DropForeignKey(
                name: "FK_InstallmentConcepts_Installments_InstallmentID",
                table: "InstallmentConcepts");

            migrationBuilder.DropForeignKey(
                name: "FK_Installments_InstallmentStatus_StatusInstallmentStatusID",
                table: "Installments");

            migrationBuilder.RenameColumn(
                name: "InstallmentStatusID",
                table: "InstallmentStatus",
                newName: "InstallmentStatusId");

            migrationBuilder.RenameColumn(
                name: "StatusInstallmentStatusID",
                table: "Installments",
                newName: "StatusInstallmentStatusId");

            migrationBuilder.RenameColumn(
                name: "InstallmentID",
                table: "Installments",
                newName: "InstallmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Installments_StatusInstallmentStatusID",
                table: "Installments",
                newName: "IX_Installments_StatusInstallmentStatusId");

            migrationBuilder.RenameColumn(
                name: "InstallmentID",
                table: "InstallmentConcepts",
                newName: "InstallmentId");

            migrationBuilder.RenameIndex(
                name: "IX_InstallmentConcepts_InstallmentID",
                table: "InstallmentConcepts",
                newName: "IX_InstallmentConcepts_InstallmentId");

            migrationBuilder.RenameColumn(
                name: "ConceptTypeID",
                table: "ConceptTypes",
                newName: "ConceptTypeId");

            migrationBuilder.RenameColumn(
                name: "ConceptTypeID",
                table: "Concepts",
                newName: "ConceptTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Concepts_ConceptTypeID",
                table: "Concepts",
                newName: "IX_Concepts_ConceptTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Concepts_ConceptTypes_ConceptTypeId",
                table: "Concepts",
                column: "ConceptTypeId",
                principalTable: "ConceptTypes",
                principalColumn: "ConceptTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InstallmentConcepts_Installments_InstallmentId",
                table: "InstallmentConcepts",
                column: "InstallmentId",
                principalTable: "Installments",
                principalColumn: "InstallmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Installments_InstallmentStatus_StatusInstallmentStatusId",
                table: "Installments",
                column: "StatusInstallmentStatusId",
                principalTable: "InstallmentStatus",
                principalColumn: "InstallmentStatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concepts_ConceptTypes_ConceptTypeId",
                table: "Concepts");

            migrationBuilder.DropForeignKey(
                name: "FK_InstallmentConcepts_Installments_InstallmentId",
                table: "InstallmentConcepts");

            migrationBuilder.DropForeignKey(
                name: "FK_Installments_InstallmentStatus_StatusInstallmentStatusId",
                table: "Installments");

            migrationBuilder.RenameColumn(
                name: "InstallmentStatusId",
                table: "InstallmentStatus",
                newName: "InstallmentStatusID");

            migrationBuilder.RenameColumn(
                name: "StatusInstallmentStatusId",
                table: "Installments",
                newName: "StatusInstallmentStatusID");

            migrationBuilder.RenameColumn(
                name: "InstallmentId",
                table: "Installments",
                newName: "InstallmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Installments_StatusInstallmentStatusId",
                table: "Installments",
                newName: "IX_Installments_StatusInstallmentStatusID");

            migrationBuilder.RenameColumn(
                name: "InstallmentId",
                table: "InstallmentConcepts",
                newName: "InstallmentID");

            migrationBuilder.RenameIndex(
                name: "IX_InstallmentConcepts_InstallmentId",
                table: "InstallmentConcepts",
                newName: "IX_InstallmentConcepts_InstallmentID");

            migrationBuilder.RenameColumn(
                name: "ConceptTypeId",
                table: "ConceptTypes",
                newName: "ConceptTypeID");

            migrationBuilder.RenameColumn(
                name: "ConceptTypeId",
                table: "Concepts",
                newName: "ConceptTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Concepts_ConceptTypeId",
                table: "Concepts",
                newName: "IX_Concepts_ConceptTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Concepts_ConceptTypes_ConceptTypeID",
                table: "Concepts",
                column: "ConceptTypeID",
                principalTable: "ConceptTypes",
                principalColumn: "ConceptTypeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InstallmentConcepts_Installments_InstallmentID",
                table: "InstallmentConcepts",
                column: "InstallmentID",
                principalTable: "Installments",
                principalColumn: "InstallmentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Installments_InstallmentStatus_StatusInstallmentStatusID",
                table: "Installments",
                column: "StatusInstallmentStatusID",
                principalTable: "InstallmentStatus",
                principalColumn: "InstallmentStatusID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
