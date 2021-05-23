using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotographyWebAppCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhotoCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Description = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 64, nullable: true),
                    Description = table.Column<string>(maxLength: 1024, nullable: true),
                    Path_Origional = table.Column<string>(nullable: true),
                    Path_Big = table.Column<string>(nullable: true),
                    Path_Middle = table.Column<string>(nullable: true),
                    Path_Small = table.Column<string>(nullable: true),
                    CaptureDateTime = table.Column<DateTime>(nullable: true),
                    LastUpdate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    PhotographerId = table.Column<int>(nullable: true),
                    AlbumId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CoverPhotoId = table.Column<int>(nullable: true),
                    ConverPhotoId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Album_PhotoCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "PhotoCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Album_Photo_CoverPhotoId",
                        column: x => x.CoverPhotoId,
                        principalTable: "Photo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photographer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Description = table.Column<string>(maxLength: 1024, nullable: false),
                    AvatarId1 = table.Column<int>(nullable: true),
                    AvatarId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photographer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photographer_Photo_AvatarId1",
                        column: x => x.AvatarId1,
                        principalTable: "Photo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_CategoryId",
                table: "Album",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Album_CoverPhotoId",
                table: "Album",
                column: "CoverPhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_AlbumId",
                table: "Photo",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_PhotographerId",
                table: "Photo",
                column: "PhotographerId");

            migrationBuilder.CreateIndex(
                name: "IX_Photographer_AvatarId1",
                table: "Photographer",
                column: "AvatarId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Album_AlbumId",
                table: "Photo",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Photographer_PhotographerId",
                table: "Photo",
                column: "PhotographerId",
                principalTable: "Photographer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_PhotoCategory_CategoryId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Album_Photo_CoverPhotoId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Photographer_Photo_AvatarId1",
                table: "Photographer");

            migrationBuilder.DropTable(
                name: "PhotoCategory");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Photographer");
        }
    }
}
