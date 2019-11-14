using Microsoft.EntityFrameworkCore.Migrations;

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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: true),
                    VacationName = table.Column<string>(nullable: true),
                    AnswerCode = table.Column<string>(nullable: true),
                    Popularity = table.Column<int>(nullable: false)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    FaveColor = table.Column<int>(nullable: false)
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
                    VacationName = table.Column<string>(nullable: true)
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
                columns: new[] { "ID", "AnswerCode", "CityName", "Popularity", "VacationName" },
                values: new object[,]
                {
                    { 1, "0,1,1,0,1", "North Korea", 3, "Chris baptism party" },
                    { 2, "0,1,3,0,0", "Paris", 69, "Chris Refugee party" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "FaveColor", "Name" },
                values: new object[,]
                {
                    { 1, 11, "Kyungrae" },
                    { 2, 12, "Karina" },
                    { 3, 13, "Biniam" },
                    { 4, 4, "Enrique" },
                    { 5, 10, "Chris" }
                });

            migrationBuilder.InsertData(
                table: "SavedTrips",
                columns: new[] { "UserID", "AnswerCode", "CityName", "VacationName" },
                values: new object[] { 1, "0,1,1,0,1", "Tunisia", "Chris bachelor party" });

            migrationBuilder.InsertData(
                table: "SavedTrips",
                columns: new[] { "UserID", "AnswerCode", "CityName", "VacationName" },
                values: new object[] { 1, "0,1,3,0,0", "Paris", "Chris divorce party" });
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
