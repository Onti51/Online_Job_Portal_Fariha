using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AvlJobsColumnUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvailablePositions",
                table: "tbl_Avl_Jobs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FilledPositions",
                table: "tbl_Avl_Jobs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "JobOpen",
                table: "tbl_Avl_Jobs",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailablePositions",
                table: "tbl_Avl_Jobs");

            migrationBuilder.DropColumn(
                name: "FilledPositions",
                table: "tbl_Avl_Jobs");

            migrationBuilder.DropColumn(
                name: "JobOpen",
                table: "tbl_Avl_Jobs");
        }
    }
}
