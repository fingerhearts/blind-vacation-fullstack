using Microsoft.EntityFrameworkCore.Migrations;

namespace BlindVacationFullstack.Migrations
{
    public partial class updatedTripsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasChildren",
                table: "SavedTrips",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InUSA",
                table: "SavedTrips",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LikesHot",
                table: "SavedTrips",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LikesOutdoor",
                table: "SavedTrips",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "SavedTrips",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasChildren",
                table: "PopularTrips",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InUSA",
                table: "PopularTrips",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LikesHot",
                table: "PopularTrips",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LikesOutdoor",
                table: "PopularTrips",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "PopularTrips",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "PopularTrips",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "LikesHot", "LikesOutdoor", "Price" },
                values: new object[] { true, true, 1 });

            migrationBuilder.UpdateData(
                table: "PopularTrips",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "LikesHot", "Price" },
                values: new object[] { true, 3 });

            migrationBuilder.UpdateData(
                table: "SavedTrips",
                keyColumns: new[] { "UserID", "AnswerCode" },
                keyValues: new object[] { 1, "0,1,1,0,1" },
                columns: new[] { "LikesHot", "LikesOutdoor", "Price" },
                values: new object[] { true, true, 1 });

            migrationBuilder.UpdateData(
                table: "SavedTrips",
                keyColumns: new[] { "UserID", "AnswerCode" },
                keyValues: new object[] { 1, "0,1,3,0,0" },
                columns: new[] { "LikesHot", "Price" },
                values: new object[] { true, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasChildren",
                table: "SavedTrips");

            migrationBuilder.DropColumn(
                name: "InUSA",
                table: "SavedTrips");

            migrationBuilder.DropColumn(
                name: "LikesHot",
                table: "SavedTrips");

            migrationBuilder.DropColumn(
                name: "LikesOutdoor",
                table: "SavedTrips");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "SavedTrips");

            migrationBuilder.DropColumn(
                name: "HasChildren",
                table: "PopularTrips");

            migrationBuilder.DropColumn(
                name: "InUSA",
                table: "PopularTrips");

            migrationBuilder.DropColumn(
                name: "LikesHot",
                table: "PopularTrips");

            migrationBuilder.DropColumn(
                name: "LikesOutdoor",
                table: "PopularTrips");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "PopularTrips");
        }
    }
}
