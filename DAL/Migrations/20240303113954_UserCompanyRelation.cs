using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserCompanyRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorUserID",
                table: "tbl_Avl_Jobs");

            migrationBuilder.AddColumn<string>(
                name: "CompanyID",
                table: "tbl_Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHiring",
                table: "tbl_Users",
                type: "boolean",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Users_CompanyID",
                table: "tbl_Users",
                column: "CompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Users_tbl_Companies_CompanyID",
                table: "tbl_Users",
                column: "CompanyID",
                principalTable: "tbl_Companies",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Users_tbl_Companies_CompanyID",
                table: "tbl_Users");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Users_CompanyID",
                table: "tbl_Users");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "tbl_Users");

            migrationBuilder.DropColumn(
                name: "IsHiring",
                table: "tbl_Users");

            migrationBuilder.AddColumn<string>(
                name: "CreatorUserID",
                table: "tbl_Avl_Jobs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
