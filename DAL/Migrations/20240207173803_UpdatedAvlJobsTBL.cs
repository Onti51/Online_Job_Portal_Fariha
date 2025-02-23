using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAvlJobsTBL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Avl_Jobs",
                columns: table => new
                {
                    Job_ID = table.Column<string>(type: "text", nullable: false),
                    CreatorUserID = table.Column<string>(type: "text", nullable: false),
                    Job_Name = table.Column<string>(type: "text", nullable: false),
                    AvailablePositions = table.Column<int>(type: "integer", nullable: false),
                    FilledPositions = table.Column<int>(type: "integer", nullable: false),
                    JobOpen = table.Column<bool>(type: "boolean", nullable: false),
                    Domain = table.Column<string>(type: "text", nullable: false),
                    SkillsRequired = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Avl_Jobs", x => x.Job_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Avl_Jobs");
        }
    }
}
