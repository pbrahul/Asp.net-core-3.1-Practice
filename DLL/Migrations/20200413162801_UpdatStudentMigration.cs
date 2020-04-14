using Microsoft.EntityFrameworkCore.Migrations;

namespace DLL.Migrations
{
    public partial class UpdatStudentMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_departmentDeptId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_departmentDeptId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "departmentDeptId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "DeptId1",
                table: "Students",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "DeptId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "departmentDeptId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_departmentDeptId",
                table: "Students",
                column: "departmentDeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_departmentDeptId",
                table: "Students",
                column: "departmentDeptId",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
