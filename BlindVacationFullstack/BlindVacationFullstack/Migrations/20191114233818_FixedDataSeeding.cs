using Microsoft.EntityFrameworkCore.Migrations;

namespace BlindVacationFullstack.Migrations
{
    public partial class FixedDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PopularTrips",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "AnswerCode", "CityName", "Price", "VacationName" },
                values: new object[] { "0,1,2,0,1", "Seoul, South Korea", 2, "Korea Vacation 2020" });

            migrationBuilder.UpdateData(
                table: "PopularTrips",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "AnswerCode", "CityName", "Price", "VacationName" },
                values: new object[] { "1,0,2,1,0", "Seattle, Washington, USA", 2, "Staycation" });

            migrationBuilder.UpdateData(
                table: "SavedTrips",
                keyColumns: new[] { "UserID", "AnswerCode" },
                keyValues: new object[] { 1, "0,1,1,0,1" },
                columns: new[] { "CityName", "VacationName" },
                values: new object[] { "Rome, Italy", "Summer Historical Holiday" });

            migrationBuilder.UpdateData(
                table: "SavedTrips",
                keyColumns: new[] { "UserID", "AnswerCode" },
                keyValues: new object[] { 1, "0,1,3,0,0" },
                columns: new[] { "CityName", "VacationName" },
                values: new object[] { "Paris, France", "We need baguettes really badly." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PopularTrips",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "AnswerCode", "CityName", "Price", "VacationName" },
                values: new object[] { "0,1,1,0,1", "North Korea", 1, "Chris baptism party" });

            migrationBuilder.UpdateData(
                table: "PopularTrips",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "AnswerCode", "CityName", "Price", "VacationName" },
                values: new object[] { "0,1,3,0,0", "Paris", 3, "Chris Refugee party" });

            migrationBuilder.UpdateData(
                table: "SavedTrips",
                keyColumns: new[] { "UserID", "AnswerCode" },
                keyValues: new object[] { 1, "0,1,1,0,1" },
                columns: new[] { "CityName", "VacationName" },
                values: new object[] { "Tunisia", "Chris bachelor party" });

            migrationBuilder.UpdateData(
                table: "SavedTrips",
                keyColumns: new[] { "UserID", "AnswerCode" },
                keyValues: new object[] { 1, "0,1,3,0,0" },
                columns: new[] { "CityName", "VacationName" },
                values: new object[] { "Paris", "Chris divorce party" });
        }
    }
}
