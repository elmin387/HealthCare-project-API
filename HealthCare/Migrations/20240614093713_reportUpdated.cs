using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.API.Migrations
{
    public partial class reportUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReportDescription",
                table: "PatientReports",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<int>(
                name: "AcceptanceId",
                table: "PatientReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PatientReports_AcceptanceId",
                table: "PatientReports",
                column: "AcceptanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReports_PatientAcceptances_AcceptanceId",
                table: "PatientReports",
                column: "AcceptanceId",
                principalTable: "PatientAcceptances",
                principalColumn: "PatientAcceptanceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientReports_PatientAcceptances_AcceptanceId",
                table: "PatientReports");

            migrationBuilder.DropIndex(
                name: "IX_PatientReports_AcceptanceId",
                table: "PatientReports");

            migrationBuilder.DropColumn(
                name: "AcceptanceId",
                table: "PatientReports");

            migrationBuilder.AlterColumn<string>(
                name: "ReportDescription",
                table: "PatientReports",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);
        }
    }
}
