using Common.Enums;
using Microsoft.EntityFrameworkCore;
using Test.Data.Entities;

namespace Test.Data
{
    public class BookLibraryContext : DbContext
    {
        public BookLibraryContext(DbContextOptions<BookLibraryContext> options) : base(options)
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

            builder.Entity<BookRequest>()
                .ToTable("BookRequests");

            builder.Entity<BookRequestDetail>()
                .ToTable("BookRequestDetails");

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
                .HasMany(b => b.BookRequests);

            builder.Entity<BookRequest>()
                .HasMany(br => br.BookRequestDetails)
                .WithOne(bd => bd.BookRequest)
                .HasForeignKey(bd => bd.RequestId);

            builder.Entity<BookRequestDetail>()
                .HasOne(bd => bd.Book);

            builder.Entity<User>()
                .HasMany(u => u.BookRequests)
                .WithOne(br => br.RequestedByUser)
                .HasForeignKey(br => br.UserId);

            builder.Entity<User>()
                .HasMany(u => u.ApprovalRequests)
                .WithOne(br => br.ApprovalModifiedByUser)
                .HasForeignKey(br => br.ApprovalById);
        }

        private void SeedData(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Culture", IsDeleted = false },
                new Category { CategoryId = 2, CategoryName = "Science", IsDeleted = false },
                new Category { CategoryId = 3, CategoryName = "Travel", IsDeleted = false }
            );

            builder.Entity<Book>().HasData(
                new Book { BookId = 1, BookName = "Book 1", CategoryId = 1, IsDeleted = false },
                new Book { BookId = 2, BookName = "Book 2", CategoryId = 2, IsDeleted = false },
                new Book { BookId = 3, BookName = "Book 3", CategoryId = 1, IsDeleted = false },
                new Book { BookId = 4, BookName = "Book 4", CategoryId = 3, IsDeleted = false },
                new Book { BookId = 5, BookName = "Book 5", CategoryId = 1, IsDeleted = false },
                new Book { BookId = 6, BookName = "Book 6", CategoryId = 3, IsDeleted = false }
            );

            builder.Entity<User>().HasData(
                new User { Id = 1, UserName = "user1", Password = "123456", Name = "Normal 1", Role = UserRoleEnum.NormalUser },
                new User { Id = 2, UserName = "user2", Password = "123456", Name = "Normal 2", Role = UserRoleEnum.NormalUser },
                new User { Id = 3, UserName = "sa1", Password = "123456", Name = "Super 1", Role = UserRoleEnum.SuperAdmin },
                new User { Id = 4, UserName = "sa2", Password = "123456", Name = "Super 2", Role = UserRoleEnum.SuperAdmin }
            );

            builder.Entity<BookRequest>().HasData(
                new BookRequest { RequestId = 1, UserId = 1, RequestedDate = DateTime.Now },
                new BookRequest { RequestId = 2, UserId = 2, RequestedDate = DateTime.Now, Status = RequestBookStatus.Approved, ApprovalById = 3 },
                new BookRequest { RequestId = 3, UserId = 2, RequestedDate = DateTime.Now, Status = RequestBookStatus.Rejected, ApprovalById = 4 }
            );

            builder.Entity<BookRequestDetail>().HasData(
                new BookRequestDetail { DetailId = 1, RequestId = 1, BookId = 3 },
                new BookRequestDetail { DetailId = 2, RequestId = 2, BookId = 3, Status = RequestBookDetailStatus.OnBeingBorrowed },
                new BookRequestDetail { DetailId = 3, RequestId = 3, BookId = 4, Status = RequestBookDetailStatus.Returned, ReturnDate = DateTime.Now }
            );
        }

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<BookRequest> BookRequests { get; set; } = null!;
        public DbSet<BookRequestDetail> BookRequestDetails { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
}
