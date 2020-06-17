using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ExpensasAbbinatura.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConceptTypes",
                columns: table => new
                {
                    ConceptTypeID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConceptTypes", x => x.ConceptTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "Concepts",
                columns: table => new
                {
                    ConceptID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ConceptTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concepts", x => x.ConceptID);
                    table.ForeignKey(
                        name: "FK_Concepts_ConceptTypes_ConceptTypeID",
                        column: x => x.ConceptTypeID,
                        principalTable: "ConceptTypes",
                        principalColumn: "ConceptTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Installments",
                columns: table => new
                {
                    InstallmentID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    When = table.Column<DateTime>(nullable: false),
                    PersonID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Installments", x => x.InstallmentID);
                    table.ForeignKey(
                        name: "FK_Installments_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstallmentConcepts",
                columns: table => new
                {
                    InstallmentConceptID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ConceptID = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    InstallmentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallmentConcepts", x => x.InstallmentConceptID);
                    table.ForeignKey(
                        name: "FK_InstallmentConcepts_Concepts_ConceptID",
                        column: x => x.ConceptID,
                        principalTable: "Concepts",
                        principalColumn: "ConceptID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstallmentConcepts_Installments_InstallmentID",
                        column: x => x.InstallmentID,
                        principalTable: "Installments",
                        principalColumn: "InstallmentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Concepts_ConceptTypeID",
                table: "Concepts",
                column: "ConceptTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentConcepts_ConceptID",
                table: "InstallmentConcepts",
                column: "ConceptID");

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentConcepts_InstallmentID",
                table: "InstallmentConcepts",
                column: "InstallmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Installments_PersonID",
                table: "Installments",
                column: "PersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstallmentConcepts");

            migrationBuilder.DropTable(
                name: "Concepts");

            migrationBuilder.DropTable(
                name: "Installments");

            migrationBuilder.DropTable(
                name: "ConceptTypes");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
