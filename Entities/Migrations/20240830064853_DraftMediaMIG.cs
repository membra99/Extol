using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class DraftMediaMIG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Draft",
                table: "ProductDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_Draft",
                table: "ProductDetails",
                column: "Draft");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Medias_Draft",
                table: "ProductDetails",
                column: "Draft",
                principalTable: "Medias",
                principalColumn: "MediaId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Medias_Draft",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_Draft",
                table: "ProductDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Draft",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
