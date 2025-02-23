using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SkillsAndQuals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Job_Qualifications",
                columns: table => new
                {
                    QualificationRequired = table.Column<string>(type: "text", nullable: false),
                    Job_ID = table.Column<string>(type: "text", nullable: false),
                    Required = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Job_Qualifications", x => x.QualificationRequired);
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
                    Skill_Name = table.Column<string>(type: "text", nullable: false),
                    Job_ID = table.Column<string>(type: "text", nullable: false),
                    Required = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Job_Skills", x => x.Skill_Name);
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
                    Name = table.Column<string>(type: "text", nullable: false),
                    User_ID = table.Column<string>(type: "text", nullable: false),
                    Institute = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_User_Qualifications", x => x.Name);
                    table.ForeignKey(
                        name: "FK_tbl_User_Qualifications_tbl_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "tbl_Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_User_Skills",
                columns: table => new
                {
                    Skill_Name = table.Column<string>(type: "text", nullable: false),
                    User_ID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_User_Skills", x => x.Skill_Name);
                    table.ForeignKey(
                        name: "FK_tbl_User_Skills_tbl_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "tbl_Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Job_Qualifications_Job_ID",
                table: "tbl_Job_Qualifications",
                column: "Job_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Job_Skills_Job_ID",
                table: "tbl_Job_Skills",
                column: "Job_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_User_Qualifications_User_ID",
                table: "tbl_User_Qualifications",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_User_Skills_User_ID",
                table: "tbl_User_Skills",
                column: "User_ID");
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

            migrationBuilder.DropTable(
                name: "tbl_User_Skills");
        }
    }
}
