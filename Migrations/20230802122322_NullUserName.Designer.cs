﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TelegramBot.DataBase;

#nullable disable

namespace TelegramBot.Migrations
{
    [DbContext(typeof(BotDbContext))]
    [Migration("20230802122322_NullUserName")]
    partial class NullUserName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TelegramBot.Models.TgUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusOnCommand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TelegramId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("TelegramId")
                        .IsUnique();

                    b.ToTable("tgUsers");
                });

            modelBuilder.Entity("TelegramBot.Models.VoiceMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<long?>("Size")
                        .HasColumnType("bigint");

                    b.Property<string>("TgId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("voiceMessages");
                });

            modelBuilder.Entity("TelegramBot.Models.VoiceMessage", b =>
                {
                    b.HasOne("TelegramBot.Models.TgUser", "tgUser")
                        .WithMany("Voices")
                        .HasForeignKey("UserId")
                        .HasPrincipalKey("TelegramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tgUser");
                });

            modelBuilder.Entity("TelegramBot.Models.TgUser", b =>
                {
                    b.Navigation("Voices");
                });
#pragma warning restore 612, 618
        }
    }
}