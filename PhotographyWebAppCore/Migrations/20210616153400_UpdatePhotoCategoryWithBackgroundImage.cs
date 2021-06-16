using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotographyWebAppCore.Migrations
{
    public partial class UpdatePhotoCategoryWithBackgroundImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BackgroundImageId",
                table: "PhotoCategory",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhotoCategory_BackgroundImageId",
                table: "PhotoCategory",
                column: "BackgroundImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoCategory_Photo_BackgroundImageId",
                table: "PhotoCategory",
                column: "BackgroundImageId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoCategory_Photo_BackgroundImageId",
                table: "PhotoCategory");

            migrationBuilder.DropIndex(
                name: "IX_PhotoCategory_BackgroundImageId",
                table: "PhotoCategory");

            migrationBuilder.DropColumn(
                name: "BackgroundImageId",
                table: "PhotoCategory");
        }
    }
}
