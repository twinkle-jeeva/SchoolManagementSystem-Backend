using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentDemoAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTeacherModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Teachers");
        }
    }
}
