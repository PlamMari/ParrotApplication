using Microsoft.EntityFrameworkCore.Migrations;

namespace ParrotsApplication.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parrots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiseLevel = table.Column<double>(type: "float", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parrots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parrots_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParrotId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Parrots_ParrotId",
                        column: x => x.ParrotId,
                        principalTable: "Parrots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "African Gray" });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Indian Blue" });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Cockatiel" });

            migrationBuilder.InsertData(
                table: "Parrots",
                columns: new[] { "Id", "Name", "NoiseLevel", "Size", "SpeciesId" },
                values: new object[,]
                {
                    { 1, "Djaro", 3.0, "Large", 1 },
                    { 3, "Gizmo", 3.0, "Large", 1 },
                    { 7, "Apollo", 3.0, "Large", 1 },
                    { 2, "Hamlet", 4.5, "Medium", 2 },
                    { 4, "Kiwi", 4.0, "Medium", 2 },
                    { 5, "YumYum", 3.0, "Small", 3 },
                    { 6, "Ginger", 3.0, "Small", 3 }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "ParrotId", "Value" },
                values: new object[,]
                {
                    { 7, 1, "https://www.youtube.com/watch?v=er9uysEEyX4" },
                    { 8, 1, "https://www.youtube.com/watch?v=7Arab-zmne0" },
                    { 1, 3, "https://www.youtube.com/shorts/YCVK-aqeAHo" },
                    { 2, 3, "https://www.youtube.com/shorts/QrmWkpblL_U" },
                    { 10, 7, "https://www.youtube.com/shorts/_AmBMMv88rI" },
                    { 11, 7, "https://www.youtube.com/shorts/FVxlikv7QWM" },
                    { 12, 7, "https://www.youtube.com/shorts/RrM9DmeevAA" },
                    { 3, 2, "https://www.youtube.com/shorts/1rLyvVi8nRU" },
                    { 4, 2, "https://www.youtube.com/shorts/EA9J3poFlOs" },
                    { 6, 4, "https://www.youtube.com/shorts/Hw8-jbTtqdA" },
                    { 5, 5, "https://www.youtube.com/shorts/UFt2pt7eTyY" },
                    { 9, 6, "https://www.youtube.com/watch?v=MIAwx3XwnsY" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parrots_SpeciesId",
                table: "Parrots",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ParrotId",
                table: "Videos",
                column: "ParrotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Parrots");

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
