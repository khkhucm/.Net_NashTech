﻿using Common.Enums;
using Microsoft.EntityFrameworkCore;
using Test.Data.Entities;

namespace Test.Data
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigureTables(builder);

            ConfigureRelationships(builder);

            SeedData(builder);
        }

        private void ConfigureTables(ModelBuilder builder)
        {
            builder.Entity<Book>()
                .ToTable("Books");

            builder.Entity<Category>()
                .ToTable("Categories");

            builder.Entity<BookBorrowingRequest>()
                .ToTable("BookBorrowingRequests");

            builder.Entity<BookBorrowingRequestDetail>()
                .ToTable("BookBorrowingRequestDetails");

            builder.Entity<User>()
                .ToTable("Users");
        }

        private void ConfigureRelationships(ModelBuilder builder)
        {
            builder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId);
            builder.Entity<Book>()
                .HasMany(b => b.BookBorrowingRequests)
                .WithMany(br => br.Books);

            builder.Entity<BookBorrowingRequest>()
                .HasMany(br => br.BookBorrowingRequestDetails)
                .WithOne(bd => bd.BookBorrowingRequest);

            builder.Entity<User>()
                .HasMany(u => u.RequestedBorrowingRequests)
                .WithOne(br => br.RequestedByUser)
                .HasForeignKey(br => br.UserId);
        }

        private void SeedData(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Culture" },
                new Category { CategoryId = 2, CategoryName = "Science" },
                new Category { CategoryId = 3, CategoryName = "Travel" }
            );

            builder.Entity<Book>().HasData(
                new Book { BookId = 1, BookName = "Book 1", CategoryId = 1 },
                new Book { BookId = 2, BookName = "Book 2", CategoryId = 2 },
                new Book { BookId = 3, BookName = "Book 3" , CategoryId = 1 },
                new Book { BookId = 4, BookName = "Book 4" , CategoryId = 3 },
                new Book { BookId = 5, BookName = "Book 5"  ,CategoryId = 1 },
                new Book { BookId = 6, BookName = "Book 6" , CategoryId = 3 }
            );

            builder.Entity<User>().HasData(
                new User { Id = 1, UserName = "user1", Password = "123456", Name = "Normal 1", Role = UserRoleEnum.NormalUser },
                new User { Id = 2, UserName = "user2", Password = "123456", Name = "Normal 2", Role = UserRoleEnum.NormalUser },
                new User { Id = 3, UserName = "sa1", Password = "123456", Name = "Super 1", Role = UserRoleEnum.SuperAdmin },
                new User { Id = 4, UserName = "sa2", Password = "123456", Name = "Super 2", Role = UserRoleEnum.SuperAdmin }
            );
        }

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<BookBorrowingRequest> BookBorrowingRequests { get; set; } = null!;
        public DbSet<BookBorrowingRequestDetail> BookBorrowingRequestDetails { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
}