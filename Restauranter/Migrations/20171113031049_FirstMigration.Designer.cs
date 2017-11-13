using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Restauranter.Models;

namespace Restauranter.Migrations
{
    [DbContext(typeof(RestauranterContext))]
    [Migration("20171113031049_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Restauranter.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Rating");

                    b.Property<string>("Restaurant_Name")
                        .IsRequired();

                    b.Property<string>("Reviewer_Name")
                        .IsRequired();

                    b.Property<string>("Reviews")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<DateTime>("Visit_Date");

                    b.HasKey("Id");

                    b.ToTable("Reviews");
                });
        }
    }
}
