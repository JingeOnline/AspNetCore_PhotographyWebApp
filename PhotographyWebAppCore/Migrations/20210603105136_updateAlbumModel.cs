using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotographyWebAppCore.Migrations
{
    public partial class updateAlbumModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Photo_CoverPhotoId1",
                table: "Album");

            migrationBuilder.DropIndex(
                name: "IX_Album_CoverPhotoId1",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "CoverPhotoId1",
                table: "Album");

            migrationBuilder.CreateIndex(
                name: "IX_Album_CoverPhotoId",
                table: "Album",
                column: "CoverPhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Photo_CoverPhotoId",
                table: "Album",
                column: "CoverPhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Photo_CoverPhotoId",
                table: "Album");

            migrationBuilder.DropIndex(
                name: "IX_Album_CoverPhotoId",
                table: "Album");

            migrationBuilder.AddColumn<int>(
                name: "CoverPhotoId1",
                table: "Album",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Album_CoverPhotoId1",
                table: "Album",
                column: "CoverPhotoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Photo_CoverPhotoId1",
                table: "Album",
                column: "CoverPhotoId1",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
