using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationCasusWasmachine.Migrations
{
    /// <inheritdoc />
    public partial class WasMachineV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeviceId",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Goals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserIdDevice",
                table: "devices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_DeviceId",
                table: "Reports",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_UserId",
                table: "Goals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_devices_UserIdDevice",
                table: "devices",
                column: "UserIdDevice");

            migrationBuilder.AddForeignKey(
                name: "FK_devices_Users_UserIdDevice",
                table: "devices",
                column: "UserIdDevice",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Users_UserId",
                table: "Goals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_devices_DeviceId",
                table: "Reports",
                column: "DeviceId",
                principalTable: "devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_devices_Users_UserIdDevice",
                table: "devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Users_UserId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_devices_DeviceId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_DeviceId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Goals_UserId",
                table: "Goals");

            migrationBuilder.DropIndex(
                name: "IX_devices_UserIdDevice",
                table: "devices");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "UserIdDevice",
                table: "devices");
        }
    }
}
