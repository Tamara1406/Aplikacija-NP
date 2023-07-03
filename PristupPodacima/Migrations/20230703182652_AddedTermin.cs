using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PristupPodacima.Migrations
{
    /// <inheritdoc />
    public partial class AddedTermin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Termini",
                columns: table => new
                {
                    TerminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VremeTermina = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GrupaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termini", x => x.TerminID);
                    table.ForeignKey(
                        name: "FK_Termini_Grupe_GrupaID",
                        column: x => x.GrupaID,
                        principalTable: "Grupe",
                        principalColumn: "GrupaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Termini_GrupaID",
                table: "Termini",
                column: "GrupaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Termini");
        }
    }
}
