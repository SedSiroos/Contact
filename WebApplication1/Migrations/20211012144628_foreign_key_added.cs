using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class foreign_key_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ContactId",
                table: "ContactAdditionalData",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ContactAdditionalData_ContactId",
                table: "ContactAdditionalData",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactAdditionalData_Contacts_ContactId",
                table: "ContactAdditionalData",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactAdditionalData_Contacts_ContactId",
                table: "ContactAdditionalData");

            migrationBuilder.DropIndex(
                name: "IX_ContactAdditionalData_ContactId",
                table: "ContactAdditionalData");

            migrationBuilder.AlterColumn<int>(
                name: "ContactId",
                table: "ContactAdditionalData",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
