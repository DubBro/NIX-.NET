using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Module4PR2.Migrations
{
    /// <inheritdoc />
    public partial class SeedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Office",
                columns: new[] { "OfficeId", "Location", "Title" },
                values: new object[,]
                {
                    { 1, "Kyiv", "Capital" },
                    { 2, "Kharkiv", "Interceptor" },
                    { 3, "Lviv", "Flying Dutchman" },
                    { 4, "Dnipro", "Black Pearl" }
                });

            migrationBuilder.InsertData(
                table: "Title",
                columns: new[] { "TitleId", "Name" },
                values: new object[,]
                {
                    { 1, "Project Manager" },
                    { 2, ".NET Developer" },
                    { 3, "Database Administrator" },
                    { 4, "Frontend Developer" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "DateOfBirth", "FirstName", "HiredDate", "LastName", "OfficeId", "TitleId" },
                values: new object[,]
                {
                    { 1, new DateTime(1955, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steve", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jobs", 1, 1 },
                    { 2, new DateTime(1984, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mark", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zuckerberg", 1, 4 },
                    { 3, new DateTime(1955, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gates", 1, 2 },
                    { 4, new DateTime(1971, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elon", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Musk", 1, 3 },
                    { 5, null, "James", new DateTime(2022, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norrington", 2, 1 },
                    { 6, new DateTime(1950, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steve", new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wozniak", 2, 2 },
                    { 7, null, "Davy", new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jones", 3, 1 },
                    { 8, null, "Bill", new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turner", 3, 4 },
                    { 9, null, "Jack", new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sparrow", 4, 1 },
                    { 10, null, "Joshamee", new DateTime(2022, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gibbs", 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "EmployeeProject",
                columns: new[] { "EmployeeProjectId", "EmployeeId", "ProjectId", "Rate", "StartedDate" },
                values: new object[,]
                {
                    { 1, 3, 1, 500m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 6, 2, 200m, new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 6, 3, 200m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 10, 4, 1000m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 4, 5, 700m, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 8, 11, 2200m, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "EmployeeProject",
                keyColumn: "EmployeeProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmployeeProject",
                keyColumn: "EmployeeProjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmployeeProject",
                keyColumn: "EmployeeProjectId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EmployeeProject",
                keyColumn: "EmployeeProjectId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EmployeeProject",
                keyColumn: "EmployeeProjectId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EmployeeProject",
                keyColumn: "EmployeeProjectId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Office",
                keyColumn: "OfficeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Office",
                keyColumn: "OfficeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Office",
                keyColumn: "OfficeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Office",
                keyColumn: "OfficeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 4);
        }
    }
}
