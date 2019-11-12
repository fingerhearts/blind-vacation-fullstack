﻿// <auto-generated />
using BlindVacationFullstack.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlindVacationFullstack.Migrations
{
    [DbContext(typeof(VacationMVCDbContext))]
    partial class VacationMVCDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlindVacationFullstack.Models.Trip", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("RecommendationCode")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID", "RecommendationCode");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("BlindVacationFullstack.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FaveColor")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            FaveColor = 11,
                            Name = "Kyungrae"
                        },
                        new
                        {
                            ID = 2,
                            FaveColor = 12,
                            Name = "Karina"
                        },
                        new
                        {
                            ID = 3,
                            FaveColor = 13,
                            Name = "Biniam"
                        },
                        new
                        {
                            ID = 4,
                            FaveColor = 4,
                            Name = "Enrique"
                        },
                        new
                        {
                            ID = 5,
                            FaveColor = 10,
                            Name = "Chris"
                        });
                });

            modelBuilder.Entity("BlindVacationFullstack.Models.Trip", b =>
                {
                    b.HasOne("BlindVacationFullstack.Models.User", "User")
                        .WithMany("Trips")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}