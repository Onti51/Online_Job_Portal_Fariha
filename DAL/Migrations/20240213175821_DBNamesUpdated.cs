using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class DBNamesUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkillsRequired",
                table: "tbl_Avl_Jobs");

            migrationBuilder.CreateTable(
                name: "tbl_Job_Qualifications",
                columns: table => new
                {
                    Job_ID = table.Column<string>(type: "text", nullable: false),
                    QualificationRequired = table.Column<string>(type: "text", nullable: false),
                    Required = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Job_Qualifications", x => x.Job_ID);
                    table.ForeignKey(
                        name: "FK_tbl_Job_Qualifications_tbl_Avl_Jobs_Job_ID",
                        column: x => x.Job_ID,
                        principalTable: "tbl_Avl_Jobs",
                        principalColumn: "Job_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Job_Skills",
                columns: table => new
                {
                    Job_ID = table.Column<string>(type: "text", nullable: false),
                    Skill_Name = table.Column<string>(type: "text", nullable: false),
                    Required = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Job_Skills", x => x.Job_ID);
                    table.ForeignKey(
                        name: "FK_tbl_Job_Skills_tbl_Avl_Jobs_Job_ID",
                        column: x => x.Job_ID,
                        principalTable: "tbl_Avl_Jobs",
                        principalColumn: "Job_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_User_Qualifications",
                columns: table => new
                {
                    User_ID = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Institute = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_User_Qualifications", x => x.User_ID);
                    table.ForeignKey(
                        name: "FK_tbl_User_Qualifications_tbl_Users_User_ID",
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
                name: "tbl_Job_Qualifications");

            migrationBuilder.DropTable(
                name: "tbl_Job_Skills");

            migrationBuilder.DropTable(
                name: "tbl_User_Qualifications");

            migrationBuilder.AddColumn<string>(
                name: "SkillsRequired",
                table: "tbl_Avl_Jobs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
