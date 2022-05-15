﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserTextDataApi.Data;

#nullable disable

namespace UserTextDataApi.Migrations
{
    [DbContext(typeof(UserTextDataDbContext))]
    partial class UserTextDataDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UserTextDataApi.Data.UserTextDataWrapper", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserData");
                });

            modelBuilder.Entity("UserTextDataApi.Data.Wrapper", b =>
                {
                    b.Property<int>("textId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("textId"), 1L, 1);

                    b.Property<int?>("UserTextDataWrapperId")
                        .HasColumnType("int");

                    b.Property<string>("textValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("textId");

                    b.HasIndex("UserTextDataWrapperId");

                    b.ToTable("Texts");
                });

            modelBuilder.Entity("UserTextDataApi.Data.Wrapper", b =>
                {
                    b.HasOne("UserTextDataApi.Data.UserTextDataWrapper", null)
                        .WithMany("Texts")
                        .HasForeignKey("UserTextDataWrapperId");
                });

            modelBuilder.Entity("UserTextDataApi.Data.UserTextDataWrapper", b =>
                {
                    b.Navigation("Texts");
                });
#pragma warning restore 612, 618
        }
    }
}
