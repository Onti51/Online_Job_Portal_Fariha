using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CompanyTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Coy_ID",
                table: "tbl_Avl_Jobs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "tbl_Companies",
                columns: table => new
                {
                    ID = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Ratin = table.Column<float>(type: "real", nullable: false),
                    Estd_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HQ_Location = table.Column<string>(type: "text", nullable: false),
                    Domain = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Companies", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Avl_Jobs_Coy_ID",
                table: "tbl_Avl_Jobs",
                column: "Coy_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Avl_Jobs_tbl_Companies_Coy_ID",
                table: "tbl_Avl_Jobs",
                column: "Coy_ID",
                principalTable: "tbl_Companies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Avl_Jobs_tbl_Companies_Coy_ID",
                table: "tbl_Avl_Jobs");

            migrationBuilder.DropTable(
                name: "tbl_Companies");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Avl_Jobs_Coy_ID",
                table: "tbl_Avl_Jobs");

            migrationBuilder.DropColumn(
                name: "Coy_ID",
                table: "tbl_Avl_Jobs");
        }
    }
}
