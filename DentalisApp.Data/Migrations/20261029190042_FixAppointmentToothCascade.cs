using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalisApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixAppointmentToothCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ToothNumbersAlls_ToothNumberId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ToothNumberId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ToothNumberId",
                table: "Appointments");

            migrationBuilder.CreateTable(
                name: "AppointmentsTeeth",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    ToothNumbersAllId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentsTeeth", x => new { x.AppointmentId, x.ToothNumbersAllId });
                    table.ForeignKey(
                        name: "FK_AppointmentsTeeth_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppointmentsTeeth_ToothNumbersAlls_ToothNumbersAllId",
                        column: x => x.ToothNumbersAllId,
                        principalTable: "ToothNumbersAlls",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentsTeeth_ToothNumbersAllId",
                table: "AppointmentsTeeth",
                column: "ToothNumbersAllId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentsTeeth");

            migrationBuilder.AddColumn<int>(
                name: "ToothNumberId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ToothNumberId",
                table: "Appointments",
                column: "ToothNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_ToothNumbersAlls_ToothNumberId",
                table: "Appointments",
                column: "ToothNumberId",
                principalTable: "ToothNumbersAlls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
