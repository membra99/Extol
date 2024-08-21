using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class MediaConnectedWithCategoryType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CategoryTypes_MediaId",
                table: "CategoryTypes",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTypes_Medias_MediaId",
                table: "CategoryTypes",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "MediaId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTypes_Medias_MediaId",
                table: "CategoryTypes");

            migrationBuilder.DropIndex(
                name: "IX_CategoryTypes_MediaId",
                table: "CategoryTypes");
        }
    }
}
