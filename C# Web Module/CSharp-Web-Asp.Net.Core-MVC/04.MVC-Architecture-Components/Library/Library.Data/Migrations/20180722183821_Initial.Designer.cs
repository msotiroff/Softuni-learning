﻿// <auto-generated />
using System;
using Library.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Data.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20180722183821_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Library.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoverImageUrl");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<bool>("IsBorrowed");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.Models.BookAuthor", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("AuthorId");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("BookAuthors");
                });

            modelBuilder.Entity("Library.Models.BookStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId");

                    b.Property<int>("BorrowerId");

                    b.Property<DateTime>("DateBorrowed");

                    b.Property<DateTime?>("DateReturned");

                    b.Property<DateTime?>("ExpirationDate");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("BorrowerId");

                    b.ToTable("BookStatuses");
                });

            modelBuilder.Entity("Library.Models.Borrower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Borrowers");
                });

            modelBuilder.Entity("Library.Models.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("Library.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<bool>("IsBorrowed");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("YouTubeTrailerId")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Library.Models.MovieDirector", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<int>("DirectorId");

                    b.HasKey("MovieId", "DirectorId");

                    b.HasIndex("DirectorId");

                    b.ToTable("MovieDirectors");
                });

            modelBuilder.Entity("Library.Models.MovieStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BorrowerId");

                    b.Property<DateTime>("DateBorrowed");

                    b.Property<DateTime?>("DateReturned");

                    b.Property<DateTime?>("ExpirationDate");

                    b.Property<int>("MovieId");

                    b.HasKey("Id");

                    b.HasIndex("BorrowerId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieStatuses");
                });

            modelBuilder.Entity("Library.Models.BookAuthor", b =>
                {
                    b.HasOne("Library.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Library.Models.Book", "Book")
                        .WithMany("Authors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Library.Models.BookStatus", b =>
                {
                    b.HasOne("Library.Models.Book", "Book")
                        .WithMany("Statuses")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Library.Models.Borrower", "Borrower")
                        .WithMany("BorrowedBooks")
                        .HasForeignKey("BorrowerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Library.Models.MovieDirector", b =>
                {
                    b.HasOne("Library.Models.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Library.Models.Movie", "Movie")
                        .WithMany("Directors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Library.Models.MovieStatus", b =>
                {
                    b.HasOne("Library.Models.Borrower", "Borrower")
                        .WithMany("BorrowedMovies")
                        .HasForeignKey("BorrowerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Library.Models.Movie", "Movie")
                        .WithMany("Statuses")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
