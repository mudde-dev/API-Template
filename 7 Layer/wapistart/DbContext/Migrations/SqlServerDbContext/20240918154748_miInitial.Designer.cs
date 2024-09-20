﻿// <auto-generated />
using System;
using DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbContext.Migrations.SqlServerDbContext
{
    [DbContext(typeof(csMainDbContext.SqlServerDbContext))]
    [Migration("20240918154748_miInitial")]
    partial class miInitial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DbModels.csAnimalDbM", b =>
                {
                    b.Property<Guid>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Kind")
                        .HasColumnType("int");

                    b.Property<int>("Mood")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Seeded")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ZooDbMZooId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("strKind")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("strMood")
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("AnimalId");

                    b.HasIndex("ZooDbMZooId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("DbModels.csZooDbM", b =>
                {
                    b.Property<Guid>("ZooId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Seeded")
                        .HasColumnType("bit");

                    b.HasKey("ZooId");

                    b.ToTable("Zoos");
                });

            modelBuilder.Entity("DbModels.csAnimalDbM", b =>
                {
                    b.HasOne("DbModels.csZooDbM", "ZooDbM")
                        .WithMany("AnimalsDbM")
                        .HasForeignKey("ZooDbMZooId");

                    b.Navigation("ZooDbM");
                });

            modelBuilder.Entity("DbModels.csZooDbM", b =>
                {
                    b.Navigation("AnimalsDbM");
                });
#pragma warning restore 612, 618
        }
    }
}
