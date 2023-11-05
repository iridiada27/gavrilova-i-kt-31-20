using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prpr.Migrations
{
    /// <inheritdoc />
    public partial class migra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_group",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "int", nullable: false, comment: "ID группы")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_group_name = table.Column<string>(type: "nvarchar(Max)", maxLength: 50, nullable: false, comment: "Название группы"),
                    c_year = table.Column<int>(type: "int", maxLength: 4, nullable: false, comment: "Год поступления")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_group_group_id", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_subject",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "int", nullable: false, comment: "ID предмета")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_subject_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Название предмета")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_subject_subject_id", x => x.subject_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false, comment: "ID студента")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_student_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Имя"),
                    c_student_surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Фамилия"),
                    c_student_otchestvo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Отчество"),
                    f_group_id = table.Column<int>(type: "int", nullable: false, comment: "ID группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_student_student_id", x => x.student_id);
                    table.ForeignKey(
                        name: "fk_f_group_id",
                        column: x => x.f_group_id,
                        principalTable: "cd_group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_otsenka",
                columns: table => new
                {
                    otsenka_id = table.Column<int>(type: "int", nullable: false, comment: "ID оценки")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_otsenka_mark = table.Column<int>(type: "int", maxLength: 10, nullable: false, comment: "Оценка"),
                    f_student_id = table.Column<int>(type: "int", nullable: false, comment: "ID студента"),
                    f_subject_id = table.Column<int>(type: "int", nullable: false, comment: "ID предмета")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_otsenka_otsenka_id", x => x.otsenka_id);
                    table.ForeignKey(
                        name: "fk_f_student_id",
                        column: x => x.f_student_id,
                        principalTable: "cd_student",
                        principalColumn: "student_id");
                    table.ForeignKey(
                        name: "fk_f_subject_id",
                        column: x => x.f_subject_id,
                        principalTable: "cd_subject",
                        principalColumn: "subject_id");
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_otsenka_fk_f_student_id",
                table: "cd_otsenka",
                column: "f_student_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_otsenka_fk_f_subject_id",
                table: "cd_otsenka",
                column: "f_subject_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_student_fk_f_group_id",
                table: "cd_student",
                column: "f_group_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_otsenka");

            migrationBuilder.DropTable(
                name: "cd_student");

            migrationBuilder.DropTable(
                name: "cd_subject");

            migrationBuilder.DropTable(
                name: "cd_group");
        }
    }
}
