﻿// <auto-generated />
using System;
using Gproject.Infrastruct.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gproject.Infrastruct.Migrations
{
    [DbContext(typeof(GProjectDbContext))]
    [Migration("20230208140355_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Gproject.Domain.MenuAggregate.Entities.MenuItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("MenuSectionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MenuSectionId");

                    b.ToTable("MenuItems", (string)null);
                });

            modelBuilder.Entity("Gproject.Domain.MenuAggregate.Entities.MenuSection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("MenuSections", (string)null);
                });

            modelBuilder.Entity("Gproject.Domain.MenuAggregate.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AverageRating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Menus", (string)null);
                });

            modelBuilder.Entity("Gproject.Domain.MenuAggregate.Entities.MenuItem", b =>
                {
                    b.HasOne("Gproject.Domain.MenuAggregate.Entities.MenuSection", "Section")
                        .WithMany("Items")
                        .HasForeignKey("MenuSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Gproject.Domain.Common.ValueObjects.DescriptionLocalized", "Description", b1 =>
                        {
                            b1.Property<Guid>("MenuItemId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DescriptionAr")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("DescriptionAr");

                            b1.Property<string>("DescriptionEn")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("DescriptionEn");

                            b1.HasKey("MenuItemId");

                            b1.ToTable("MenuItems");

                            b1.WithOwner()
                                .HasForeignKey("MenuItemId");
                        });

                    b.OwnsOne("Gproject.Domain.Common.ValueObjects.DescriptionLocalized", "Name", b1 =>
                        {
                            b1.Property<Guid>("MenuItemId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DescriptionAr")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("NameAr");

                            b1.Property<string>("DescriptionEn")
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("NameEn");

                            b1.HasKey("MenuItemId");

                            b1.ToTable("MenuItems");

                            b1.WithOwner()
                                .HasForeignKey("MenuItemId");
                        });

                    b.Navigation("Description");

                    b.Navigation("Name");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("Gproject.Domain.MenuAggregate.Entities.MenuSection", b =>
                {
                    b.HasOne("Gproject.Domain.MenuAggregate.Menu", "Menu")
                        .WithMany("Sections")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Gproject.Domain.Common.ValueObjects.DescriptionLocalized", "Description", b1 =>
                        {
                            b1.Property<Guid>("MenuSectionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DescriptionAr")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("DescriptionAr");

                            b1.Property<string>("DescriptionEn")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("DescriptionEn");

                            b1.HasKey("MenuSectionId");

                            b1.ToTable("MenuSections");

                            b1.WithOwner()
                                .HasForeignKey("MenuSectionId");
                        });

                    b.OwnsOne("Gproject.Domain.Common.ValueObjects.DescriptionLocalized", "Name", b1 =>
                        {
                            b1.Property<Guid>("MenuSectionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DescriptionAr")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("NameAr");

                            b1.Property<string>("DescriptionEn")
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("NameEn");

                            b1.HasKey("MenuSectionId");

                            b1.ToTable("MenuSections");

                            b1.WithOwner()
                                .HasForeignKey("MenuSectionId");
                        });

                    b.Navigation("Description");

                    b.Navigation("Menu");

                    b.Navigation("Name");
                });

            modelBuilder.Entity("Gproject.Domain.MenuAggregate.Menu", b =>
                {
                    b.OwnsOne("Gproject.Domain.Common.ValueObjects.DescriptionLocalized", "Description", b1 =>
                        {
                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DescriptionAr")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("DescriptionAr");

                            b1.Property<string>("DescriptionEn")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("DescriptionEn");

                            b1.HasKey("MenuId");

                            b1.ToTable("Menus");

                            b1.WithOwner()
                                .HasForeignKey("MenuId");
                        });

                    b.OwnsOne("Gproject.Domain.Common.ValueObjects.DescriptionLocalized", "Name", b1 =>
                        {
                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DescriptionAr")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("NameAr");

                            b1.Property<string>("DescriptionEn")
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("NameEn");

                            b1.HasKey("MenuId");

                            b1.ToTable("Menus");

                            b1.WithOwner()
                                .HasForeignKey("MenuId");
                        });

                    b.Navigation("Description");

                    b.Navigation("Name");
                });

            modelBuilder.Entity("Gproject.Domain.MenuAggregate.Entities.MenuSection", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Gproject.Domain.MenuAggregate.Menu", b =>
                {
                    b.Navigation("Sections");
                });
#pragma warning restore 612, 618
        }
    }
}
