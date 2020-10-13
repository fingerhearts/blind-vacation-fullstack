using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BlindVacationFullstack.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PopularTrips",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityName = table.Column<string>(nullable: true),
                    VacationName = table.Column<string>(nullable: true),
                    AnswerCode = table.Column<string>(nullable: true),
                    Popularity = table.Column<int>(nullable: false),
                    InUSA = table.Column<bool>(nullable: false),
                    LikesHot = table.Column<bool>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    HasChildren = table.Column<bool>(nullable: false),
                    LikesOutdoor = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopularTrips", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    FaveTripItem = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SavedTrips",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    AnswerCode = table.Column<string>(nullable: false),
                    CityName = table.Column<string>(nullable: true),
                    VacationName = table.Column<string>(nullable: true),
                    InUSA = table.Column<bool>(nullable: false),
                    LikesHot = table.Column<bool>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    HasChildren = table.Column<bool>(nullable: false),
                    LikesOutdoor = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedTrips", x => new { x.UserID, x.AnswerCode });
                    table.ForeignKey(
                        name: "FK_SavedTrips_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PopularTrips",
                columns: new[] { "ID", "AnswerCode", "CityName", "HasChildren", "InUSA", "LikesHot", "LikesOutdoor", "Popularity", "Price", "VacationName" },
                values: new object[,]
                {
                    { 1, "0,1,2,0,1", "Seoul, South Korea", false, false, true, true, 3, 2, "Korea Vacation 2020" },
                    { 2, "0,0,2,0,0", "Moscow, Russia", false, false, false, false, 69, 2, "Bring a coat!!" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "FaveTripItem", "Name" },
                values: new object[,]
                {
                    { 1, 2, "Kyungrae" },
                    { 2, 16, "Karina" },
                    { 3, 12, "Biniam" },
                    { 4, 15, "Enrique" },
                    { 5, 10, "Chris" }
                });

            migrationBuilder.InsertData(
                table: "SavedTrips",
                columns: new[] { "UserID", "AnswerCode", "CityName", "HasChildren", "InUSA", "LikesHot", "LikesOutdoor", "Price", "VacationName" },
                values: new object[] { 1, "0,1,3,0,0", "Paris, France", false, false, true, false, 3, "We need baguettes really badly." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PopularTrips");

            migrationBuilder.DropTable(
                name: "SavedTrips");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
