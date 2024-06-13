using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.API.Migrations
{
    public partial class patientAcceptanceUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "PatientReports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "PatientReports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PatientReports",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserCreatedId",
                table: "PatientReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserModifiedId",
                table: "PatientReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "PatientAcceptances",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "PatientAcceptances",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PatientAcceptances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserCreatedId",
                table: "PatientAcceptances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserModifiedId",
                table: "PatientAcceptances",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "PatientReports");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "PatientReports");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PatientReports");

            migrationBuilder.DropColumn(
                name: "UserCreatedId",
                table: "PatientReports");

            migrationBuilder.DropColumn(
                name: "UserModifiedId",
                table: "PatientReports");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "PatientAcceptances");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "PatientAcceptances");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PatientAcceptances");

            migrationBuilder.DropColumn(
                name: "UserCreatedId",
                table: "PatientAcceptances");

            migrationBuilder.DropColumn(
                name: "UserModifiedId",
                table: "PatientAcceptances");
        }
    }
}
