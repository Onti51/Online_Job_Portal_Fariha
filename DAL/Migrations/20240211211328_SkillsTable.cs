using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SkillsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ratin",
                table: "tbl_Companies",
                newName: "Rating");

            migrationBuilder.CreateTable(
                name: "tbl_User_Skills",
                columns: table => new
                {
                    User_ID = table.Column<string>(type: "text", nullable: false),
                    Skill_Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_User_Skills", x => x.User_ID);
                    table.ForeignKey(
                        name: "FK_tbl_User_Skills_tbl_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "tbl_Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_User_Skills");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "tbl_Companies",
                newName: "Ratin");
        }
    }
}
