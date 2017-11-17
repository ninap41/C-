using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BeltExam.Models;

namespace BeltExam.Migrations
{
    [DbContext(typeof(BeltExamContext))]
    partial class BeltExamContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("BeltExam.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created_At");

                    b.Property<int>("MessageId");

                    b.Property<DateTime>("Updated_At");

                    b.Property<int>("UserId");

                    b.HasKey("CommentId");

                    b.HasIndex("MessageId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BeltExam.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created_At");

                    b.Property<int>("Posted_For");

                    b.Property<DateTime>("Updated_At");

                    b.Property<int>("UserId");

                    b.HasKey("MessageId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("BeltExam.Models.User", b =>
                {
                    b.Property<int>("UsersId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created_at");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<string>("First_Name");

                    b.Property<string>("Last_Name");

                    b.Property<string>("Password");

                    b.Property<DateTime>("Updated_at");

                    b.Property<string>("User_Level");

                    b.HasKey("UsersId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BeltExam.Models.Comment", b =>
                {
                    b.HasOne("BeltExam.Models.Message", "Message")
                        .WithMany("Comments")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BeltExam.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeltExam.Models.Message", b =>
                {
                    b.HasOne("BeltExam.Models.User", "Creator")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
