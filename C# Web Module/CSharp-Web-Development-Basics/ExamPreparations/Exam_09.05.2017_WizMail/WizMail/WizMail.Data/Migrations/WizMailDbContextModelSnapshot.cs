﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WizMail.Data;

namespace WizMail.Data.Migrations
{
    [DbContext(typeof(WizMailDbContext))]
    partial class WizMailDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WizMail.Models.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Attachment");

                    b.Property<int>("FlagId");

                    b.Property<string>("Message")
                        .IsRequired();

                    b.Property<DateTime>("SendDate");

                    b.Property<int>("SenderId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("FlagId");

                    b.HasIndex("SenderId");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("WizMail.Models.Flag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Flags");
                });

            modelBuilder.Entity("WizMail.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("PassowrdHash")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WizMail.Models.UserEmail", b =>
                {
                    b.Property<int>("EmailId");

                    b.Property<int>("RecipientId");

                    b.HasKey("EmailId", "RecipientId");

                    b.HasIndex("RecipientId");

                    b.ToTable("UserEmails");
                });

            modelBuilder.Entity("WizMail.Models.Email", b =>
                {
                    b.HasOne("WizMail.Models.Flag", "Flag")
                        .WithMany()
                        .HasForeignKey("FlagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WizMail.Models.User", "Sender")
                        .WithMany("SentEmails")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WizMail.Models.UserEmail", b =>
                {
                    b.HasOne("WizMail.Models.Email", "Email")
                        .WithMany("Recipients")
                        .HasForeignKey("EmailId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WizMail.Models.User", "Recipient")
                        .WithMany("RecievedEmails")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}