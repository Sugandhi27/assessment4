// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherAPI.Models;

namespace WeatherAPI.Migrations
{
    [DbContext(typeof(WeatherContext))]
    [Migration("20210521174951_newmigration")]
    partial class newmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeatherAPI.Models.WeatherDetail", b =>
                {
                    b.Property<string>("City")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("ForCast")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HighTemp")
                        .HasColumnType("int");

                    b.Property<int>("LowTemp")
                        .HasColumnType("int");

                    b.Property<int>("WeatherID")
                        .HasColumnType("int");

                    b.HasKey("City");

                    b.ToTable("WeatherDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
