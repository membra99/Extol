using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class OpeningStyleAndMatColAndDoorHandle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryTypes",
                columns: table => new
                {
                    CategoryTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTypes", x => x.CategoryTypeId);
                    table.ForeignKey(
                        name: "FK_CategoryTypes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoorHandles",
                columns: table => new
                {
                    DoorHandleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoorHandles", x => x.DoorHandleId);
                    table.ForeignKey(
                        name: "FK_DoorHandles_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoorHandles_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "MediaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialColors",
                columns: table => new
                {
                    MaterialColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSpecial = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialColors", x => x.MaterialColorId);
                    table.ForeignKey(
                        name: "FK_MaterialColors_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OpeningStyles",
                columns: table => new
                {
                    OpeningStyleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryTypeId = table.Column<int>(type: "int", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningStyles", x => x.OpeningStyleId);
                    table.ForeignKey(
                        name: "FK_OpeningStyles_CategoryTypes_CategoryTypeId",
                        column: x => x.CategoryTypeId,
                        principalTable: "CategoryTypes",
                        principalColumn: "CategoryTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpeningStyles_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "MediaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTypes_CategoryId",
                table: "CategoryTypes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DoorHandles_MaterialId",
                table: "DoorHandles",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_DoorHandles_MediaId",
                table: "DoorHandles",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialColors_MaterialId",
                table: "MaterialColors",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningStyles_CategoryTypeId",
                table: "OpeningStyles",
                column: "CategoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningStyles_MediaId",
                table: "OpeningStyles",
                column: "MediaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoorHandles");

            migrationBuilder.DropTable(
                name: "MaterialColors");

            migrationBuilder.DropTable(
                name: "OpeningStyles");

            migrationBuilder.DropTable(
                name: "CategoryTypes");
        }
    }
}
