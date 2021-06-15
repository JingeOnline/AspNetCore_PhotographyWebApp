using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotographyWebAppCore.Migrations
{
    public partial class UpdatePhotoCategoryModelWithCoverPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoverPhotoId",
                table: "PhotoCategory",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhotoCategory_CoverPhotoId",
                table: "PhotoCategory",
                column: "CoverPhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoCategory_Photo_CoverPhotoId",
                table: "PhotoCategory",
                column: "CoverPhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoCategory_Photo_CoverPhotoId",
                table: "PhotoCategory");

            migrationBuilder.DropIndex(
                name: "IX_PhotoCategory_CoverPhotoId",
                table: "PhotoCategory");

            migrationBuilder.DropColumn(
                name: "CoverPhotoId",
                table: "PhotoCategory");
        }
    }
}
