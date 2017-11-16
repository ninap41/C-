using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using loginRegBoiler.Models;

namespace loginRegBoiler.Migrations
{
    [DbContext(typeof(loginRegBoilerContext))]
    [Migration("20171116024903_YourMigratop")]
    partial class YourMigratop
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("loginRegBoiler.Models.User", b =>
                {
                    b.Property<int>("UsersId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created_at");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("First_Name")
                        .IsRequired();

                    b.Property<string>("Last_Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<DateTime>("Updated_at");

                    b.HasKey("UsersId");

                    b.ToTable("Users");
                });
        }
    }
}
