using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationCasusWasmachine.Migrations
{
    /// <inheritdoc />
    public partial class V4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsingReport_devices_DeviceId",
                table: "UsingReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsingReport",
                table: "UsingReport");

            migrationBuilder.RenameTable(
                name: "UsingReport",
                newName: "UsingReports");

            migrationBuilder.RenameIndex(
                name: "IX_UsingReport_DeviceId",
                table: "UsingReports",
                newName: "IX_UsingReports_DeviceId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsingReports",
                table: "UsingReports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsingReports_devices_DeviceId",
                table: "UsingReports",
                column: "DeviceId",
                principalTable: "devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsingReports_devices_DeviceId",
                table: "UsingReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsingReports",
                table: "UsingReports");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "UsingReports",
                newName: "UsingReport");

            migrationBuilder.RenameIndex(
                name: "IX_UsingReports_DeviceId",
                table: "UsingReport",
                newName: "IX_UsingReport_DeviceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsingReport",
                table: "UsingReport",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsingReport_devices_DeviceId",
                table: "UsingReport",
                column: "DeviceId",
                principalTable: "devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
