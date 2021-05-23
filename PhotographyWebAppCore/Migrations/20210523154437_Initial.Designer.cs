﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhotographyWebAppCore.Models;

namespace PhotographyWebAppCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210523154437_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhotographyWebAppCore.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("ConverPhotoId")
                        .HasColumnType("int");

                    b.Property<int?>("CoverPhotoId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int>("Title")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CoverPhotoId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("PhotographyWebAppCore.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CaptureDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<DateTime>("LastUpdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Path_Big")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path_Middle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path_Origional")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path_Small")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PhotographerId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("PhotographerId");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("PhotographyWebAppCore.Models.PhotoCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("PhotoCategory");
                });

            modelBuilder.Entity("PhotographyWebAppCore.Models.Photographer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AvatarId")
                        .HasColumnType("int");

                    b.Property<int?>("AvatarId1")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("AvatarId1");

                    b.ToTable("Photographer");
                });

            modelBuilder.Entity("PhotographyWebAppCore.Models.Album", b =>
                {
                    b.HasOne("PhotographyWebAppCore.Models.PhotoCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("PhotographyWebAppCore.Models.Photo", "CoverPhoto")
                        .WithMany()
                        .HasForeignKey("CoverPhotoId");
                });

            modelBuilder.Entity("PhotographyWebAppCore.Models.Photo", b =>
                {
                    b.HasOne("PhotographyWebAppCore.Models.Album", null)
                        .WithMany("Photos")
                        .HasForeignKey("AlbumId");

                    b.HasOne("PhotographyWebAppCore.Models.Photographer", "Photographer")
                        .WithMany("Photos")
                        .HasForeignKey("PhotographerId");
                });

            modelBuilder.Entity("PhotographyWebAppCore.Models.Photographer", b =>
                {
                    b.HasOne("PhotographyWebAppCore.Models.Photo", "Avatar")
                        .WithMany()
                        .HasForeignKey("AvatarId1");
                });
#pragma warning restore 612, 618
        }
    }
}