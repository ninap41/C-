using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Woods.Models;

namespace Woods.Migrations
{
    [DbContext(typeof(WoodsContext))]
    [Migration("20171113050623_YourMigrationName")]
    partial class YourMigrationName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Woods.Models.Trail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<int>("Elevation_Change");

                    b.Property<float>("Latitude");

                    b.Property<float>("Longitude");

                    b.Property<float>("Trail_Length");

                    b.Property<string>("Trail_Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Trails");
                });
        }
    }
}
