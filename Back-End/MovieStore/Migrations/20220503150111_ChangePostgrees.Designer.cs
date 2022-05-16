﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieStore.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MovieStore.Migrations
{
    [DbContext(typeof(LocadoraContext))]
    [Migration("20220503150111_ChangePostgrees")]
    partial class ChangePostgrees
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasPostgresExtension("uuid-ossp")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("MovieStore.Domain.Director", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("MovieStore.Domain.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("AgeGroup")
                        .IsRequired()
                        .HasColumnType("CHAR(2)");

                    b.Property<Guid>("DirectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("INT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.HasIndex("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MovieStore.Domains.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PublicId")
                        .HasColumnType("uuid");

                    b.Property<string>("SecureUrl")
                        .IsRequired()
                        .HasColumnType("VARCHAR(MAX)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId")
                        .IsUnique();

                    b.ToTable("Images");
                });

            modelBuilder.Entity("MovieStore.Domain.Movie", b =>
                {
                    b.HasOne("MovieStore.Domain.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId")
                        .HasConstraintName("FK_Id_Director")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");
                });

            modelBuilder.Entity("MovieStore.Domains.Image", b =>
                {
                    b.HasOne("MovieStore.Domain.Movie", "Movie")
                        .WithOne("Image")
                        .HasForeignKey("MovieStore.Domains.Image", "MovieId")
                        .HasConstraintName("FK_Id_Movie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieStore.Domain.Director", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MovieStore.Domain.Movie", b =>
                {
                    b.Navigation("Image");
                });
#pragma warning restore 612, 618
        }
    }
}
