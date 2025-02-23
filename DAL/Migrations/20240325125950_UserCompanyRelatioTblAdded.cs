using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserCompanyRelatioTblAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_User_Secrets",
                columns: table => new
                {
                    User_ID = table.Column<string>(type: "text", nullable: false),
                    pw = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_User_Secrets", x => x.User_ID);
                    table.ForeignKey(
                        name: "FK_tbl_User_Secrets_tbl_Users_User_ID",
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
                name: "tbl_User_Secrets");
        }
    }
}
