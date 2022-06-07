﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Data;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(AlbumContext))]
    partial class AlbumContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("Entities.Album", b =>
                {
                    b.Property<string>("Title")
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.HasKey("Title");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("Entities.Image", b =>
                {
                    b.Property<string>("Title")
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.Property<string>("AlbumTitle")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Title");

                    b.HasIndex("AlbumTitle");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Entities.Image", b =>
                {
                    b.HasOne("Entities.Album", null)
                        .WithMany("Images")
                        .HasForeignKey("AlbumTitle");
                });

            modelBuilder.Entity("Entities.Album", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}