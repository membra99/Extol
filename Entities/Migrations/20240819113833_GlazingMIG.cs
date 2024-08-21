using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class GlazingMIG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Chambers",
                table: "Profiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Glazings",
                columns: table => new
                {
                    GlazingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayerNum = table.Column<int>(type: "int", nullable: false),
                    GlazingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Glazings", x => x.GlazingId);
                    table.ForeignKey(
                        name: "FK_Glazings_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "MediaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Glazings_MediaId",
                table: "Glazings",
                column: "MediaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Glazings");

            migrationBuilder.DropColumn(
                name: "Chambers",
                table: "Profiles");
        }
    }
}
