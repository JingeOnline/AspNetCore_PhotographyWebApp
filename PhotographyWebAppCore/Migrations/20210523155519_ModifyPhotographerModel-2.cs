using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotographyWebAppCore.Migrations
{
    public partial class ModifyPhotographerModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photographer_Photo_AvatarId1",
                table: "Photographer");

            migrationBuilder.DropIndex(
                name: "IX_Photographer_AvatarId1",
                table: "Photographer");

            migrationBuilder.DropColumn(
                name: "AvatarId1",
                table: "Photographer");

            migrationBuilder.CreateIndex(
                name: "IX_Photographer_AvatarId",
                table: "Photographer",
                column: "AvatarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photographer_Photo_AvatarId",
                table: "Photographer",
                column: "AvatarId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photographer_Photo_AvatarId",
                table: "Photographer");

            migrationBuilder.DropIndex(
                name: "IX_Photographer_AvatarId",
                table: "Photographer");

            migrationBuilder.AddColumn<int>(
                name: "AvatarId1",
                table: "Photographer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photographer_AvatarId1",
                table: "Photographer",
                column: "AvatarId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Photographer_Photo_AvatarId1",
                table: "Photographer",
                column: "AvatarId1",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
