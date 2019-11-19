using Microsoft.EntityFrameworkCore.Migrations;

namespace BlindVacationFullstack.Migrations
{
    public partial class FixedSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SavedTrips",
                keyColumns: new[] { "UserID", "AnswerCode" },
                keyValues: new object[] { 1, "0,1,1,0,1" });

            migrationBuilder.UpdateData(
                table: "PopularTrips",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "AnswerCode", "CityName", "LikesHot", "VacationName" },
                values: new object[] { "0,0,2,0,0", "Moscow, Russia", false, "Bring a coat!!" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PopularTrips",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "AnswerCode", "CityName", "LikesHot", "VacationName" },
                values: new object[] { "1,0,2,1,0", "Seattle, Washington, USA", true, "Staycation" });

            migrationBuilder.InsertData(
                table: "SavedTrips",
                columns: new[] { "UserID", "AnswerCode", "CityName", "HasChildren", "InUSA", "LikesHot", "LikesOutdoor", "Price", "VacationName" },
                values: new object[] { 1, "0,1,1,0,1", "Rome, Italy", false, false, true, true, 1, "Summer Historical Holiday" });
        }
    }
}
