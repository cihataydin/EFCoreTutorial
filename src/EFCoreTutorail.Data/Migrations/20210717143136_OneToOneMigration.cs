using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreTutorail.Data.Migrations
{
    public partial class OneToOneMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "student_id",
                schema: "dbo",
                table: "student_addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_student_addresses_student_id",
                schema: "dbo",
                table: "student_addresses",
                column: "student_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "student_address_id_fk",
                schema: "dbo",
                table: "student_addresses",
                column: "student_id",
                principalSchema: "dbo",
                principalTable: "students",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "student_address_id_fk",
                schema: "dbo",
                table: "student_addresses");

            migrationBuilder.DropIndex(
                name: "IX_student_addresses_student_id",
                schema: "dbo",
                table: "student_addresses");

            migrationBuilder.DropColumn(
                name: "student_id",
                schema: "dbo",
                table: "student_addresses");
        }
    }
}
