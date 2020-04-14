using Microsoft.EntityFrameworkCore.Migrations;

namespace DLL.Migrations
{
    public partial class UpdateStudentMigra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DeptId1",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DeptId1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DeptId1",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "DeptID",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_DeptID",
                table: "Students",
                column: "DeptID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DeptID",
                table: "Students",
                column: "DeptID",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DeptID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DeptID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DeptID",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "DeptId1",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_DeptId1",
                table: "Students",
                column: "DeptId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DeptId1",
                table: "Students",
                column: "DeptId1",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
