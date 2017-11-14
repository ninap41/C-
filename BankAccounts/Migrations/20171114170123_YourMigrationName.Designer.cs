﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BankAccount.Models;

namespace BankAccounts.Migrations
{
    [DbContext(typeof(BankAccountContext))]
    [Migration("20171114170123_YourMigrationName")]
    partial class YourMigrationName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("BankAccount.Models.Account", b =>
                {
                    b.Property<int>("AccountsId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Balance");

                    b.HasKey("AccountsId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BankAccount.Models.User", b =>
                {
                    b.Property<int>("UsersId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountsID");

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

                    b.HasIndex("AccountsID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BankAccount.Models.User", b =>
                {
                    b.HasOne("BankAccount.Models.Account", "userAccount")
                        .WithMany()
                        .HasForeignKey("AccountsID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
