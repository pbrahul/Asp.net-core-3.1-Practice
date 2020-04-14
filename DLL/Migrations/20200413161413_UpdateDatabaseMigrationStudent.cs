using Microsoft.EntityFrameworkCore.Migrations;

namespace DLL.Migrations
{
    public partial class UpdateDatabaseMigrationStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeptId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "departmentDeptId",
                table: "Students",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
