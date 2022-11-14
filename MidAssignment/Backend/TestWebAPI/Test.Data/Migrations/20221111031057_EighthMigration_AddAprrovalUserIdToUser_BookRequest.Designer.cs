﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test.Data;

#nullable disable

namespace Test.Data.Migrations
{
    [DbContext(typeof(BookLibraryContext))]
    [Migration("20221111031057_EighthMigration_AddAprrovalUserIdToUser_BookRequest")]
    partial class EighthMigration_AddAprrovalUserIdToUser_BookRequest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Test.Data.Entities.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"), 1L, 1);

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("BookId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books", (string)null);

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            BookName = "Book 1",
                            CategoryId = 1,
                            IsDeleted = false
                        },
                        new
                        {
                            BookId = 2,
                            BookName = "Book 2",
                            CategoryId = 2,
                            IsDeleted = false
                        },
                        new
                        {
                            BookId = 3,
                            BookName = "Book 3",
                            CategoryId = 1,
                            IsDeleted = false
                        },
                        new
                        {
                            BookId = 4,
                            BookName = "Book 4",
                            CategoryId = 3,
                            IsDeleted = false
                        },
                        new
                        {
                            BookId = 5,
                            BookName = "Book 5",
                            CategoryId = 1,
                            IsDeleted = false
                        },
                        new
                        {
                            BookId = 6,
                            BookName = "Book 6",
                            CategoryId = 3,
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("Test.Data.Entities.BookRequest", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestId"), 1L, 1);

                    b.Property<int?>("ApprovalById")
                        .HasColumnType("int");

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RequestedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RequestId");

                    b.HasIndex("ApprovalById")
                        .IsUnique()
                        .HasFilter("[ApprovalById] IS NOT NULL");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("BookRequests", (string)null);

                    b.HasData(
                        new
                        {
                            RequestId = 1,
                            RequestedDate = new DateTime(2022, 11, 11, 10, 10, 57, 218, DateTimeKind.Local).AddTicks(820),
                            Status = 0,
                            UserId = 1
                        },
                        new
                        {
                            RequestId = 2,
                            ApprovalById = 3,
                            RequestedDate = new DateTime(2022, 11, 11, 10, 10, 57, 218, DateTimeKind.Local).AddTicks(836),
                            Status = 0,
                            UserId = 2
                        },
                        new
                        {
                            RequestId = 3,
                            ApprovalById = 4,
                            RequestedDate = new DateTime(2022, 11, 11, 10, 10, 57, 218, DateTimeKind.Local).AddTicks(838),
                            Status = 1,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Test.Data.Entities.BookRequestDetail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetailId"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("DetailId");

                    b.HasIndex("BookId");

                    b.HasIndex("RequestId");

                    b.ToTable("BookRequestDetails", (string)null);

                    b.HasData(
                        new
                        {
                            DetailId = 1,
                            BookId = 3,
                            RequestId = 1,
                            Status = 0
                        },
                        new
                        {
                            DetailId = 2,
                            BookId = 3,
                            RequestId = 2,
                            Status = 1
                        },
                        new
                        {
                            DetailId = 3,
                            BookId = 4,
                            RequestId = 3,
                            ReturnDate = new DateTime(2022, 11, 11, 10, 10, 57, 218, DateTimeKind.Local).AddTicks(860),
                            Status = 2
                        });
                });

            modelBuilder.Entity("Test.Data.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Culture",
                            IsDeleted = false
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Science",
                            IsDeleted = false
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Travel",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("Test.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Normal 1",
                            Password = "123456",
                            Role = 1,
                            UserName = "user1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Normal 2",
                            Password = "123456",
                            Role = 1,
                            UserName = "user2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Super 1",
                            Password = "123456",
                            Role = 0,
                            UserName = "sa1"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Super 2",
                            Password = "123456",
                            Role = 0,
                            UserName = "sa2"
                        });
                });

            modelBuilder.Entity("Test.Data.Entities.Book", b =>
                {
                    b.HasOne("Test.Data.Entities.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Test.Data.Entities.BookRequest", b =>
                {
                    b.HasOne("Test.Data.Entities.User", "ApprovalModifiedByUser")
                        .WithOne("ApprovalRequests")
                        .HasForeignKey("Test.Data.Entities.BookRequest", "ApprovalById");

                    b.HasOne("Test.Data.Entities.Book", null)
                        .WithMany("BookRequests")
                        .HasForeignKey("BookId");

                    b.HasOne("Test.Data.Entities.User", "RequestedByUser")
                        .WithMany("BookRequests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApprovalModifiedByUser");

                    b.Navigation("RequestedByUser");
                });

            modelBuilder.Entity("Test.Data.Entities.BookRequestDetail", b =>
                {
                    b.HasOne("Test.Data.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test.Data.Entities.BookRequest", "BookRequest")
                        .WithMany("BookRequestDetails")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("BookRequest");
                });

            modelBuilder.Entity("Test.Data.Entities.Book", b =>
                {
                    b.Navigation("BookRequests");
                });

            modelBuilder.Entity("Test.Data.Entities.BookRequest", b =>
                {
                    b.Navigation("BookRequestDetails");
                });

            modelBuilder.Entity("Test.Data.Entities.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Test.Data.Entities.User", b =>
                {
                    b.Navigation("ApprovalRequests");

                    b.Navigation("BookRequests");
                });
#pragma warning restore 612, 618
        }
    }
}