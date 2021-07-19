using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreTutorail.Data.Migrations
{
    public partial class OneToManyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "books",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    author = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    student_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.id);
                    table.ForeignKey(
                        name: "student_book_id_fk",
                        column: x => x.student_id,
                        principalSchema: "dbo",
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_student_id",
                schema: "dbo",
                table: "books",
                column: "student_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books",
                schema: "dbo");
        }
    }
}
