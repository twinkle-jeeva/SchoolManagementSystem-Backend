using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentDemoAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateModelsChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emergency_Contacts_Parents_ParentId",
                table: "Emergency_Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Parents_ParentId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ParentId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Emergency_Contacts",
                table: "Emergency_Contacts");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Parents");

            migrationBuilder.RenameTable(
                name: "Emergency_Contacts",
                newName: "EmergencyContacts");

            migrationBuilder.RenameIndex(
                name: "IX_Emergency_Contacts_ParentId",
                table: "EmergencyContacts",
                newName: "IX_EmergencyContacts_ParentId");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "EmergencyContacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "EmergencyContacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmergencyContacts",
                table: "EmergencyContacts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "StudentParents",
                columns: table => new
                {
                    ParentsId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentParents", x => new { x.ParentsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_StudentParents_Parents_ParentsId",
                        column: x => x.ParentsId,
                        principalTable: "Parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentParents_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContacts_StudentId",
                table: "EmergencyContacts",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentParents_StudentsId",
                table: "StudentParents",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContacts_Parents_ParentId",
                table: "EmergencyContacts",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContacts_Students_StudentId",
                table: "EmergencyContacts",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContacts_Parents_ParentId",
                table: "EmergencyContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContacts_Students_StudentId",
                table: "EmergencyContacts");

            migrationBuilder.DropTable(
                name: "StudentParents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmergencyContacts",
                table: "EmergencyContacts");

            migrationBuilder.DropIndex(
                name: "IX_EmergencyContacts_StudentId",
                table: "EmergencyContacts");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "EmergencyContacts");

            migrationBuilder.RenameTable(
                name: "EmergencyContacts",
                newName: "Emergency_Contacts");

            migrationBuilder.RenameIndex(
                name: "IX_EmergencyContacts_ParentId",
                table: "Emergency_Contacts",
                newName: "IX_Emergency_Contacts_ParentId");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Parents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Emergency_Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emergency_Contacts",
                table: "Emergency_Contacts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ParentId",
                table: "Students",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emergency_Contacts_Parents_ParentId",
                table: "Emergency_Contacts",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Parents_ParentId",
                table: "Students",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
