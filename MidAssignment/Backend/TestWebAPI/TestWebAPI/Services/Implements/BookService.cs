using Test.Data.Entities;
using Test.Data.Repositories.Interfaces;
using TestWebAPI.DTOs.Book;
using TestWebAPI.DTOs.Category;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Services.Implements
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookService(IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

        public CreateBookResponse? Create(CreateBookRequest addModel)
        {
            using var transaction = _bookRepository.DatabaseTransaction();

            try
            {
                var category = _categoryRepository.Get(i => i.CategoryId == addModel.CategoryId);

                if (category != null)
                {
                    var newBook = new Book
                    {
                        BookName = addModel.Name,
                        CategoryId = addModel.CategoryId,
                        Category = category
                    };

                    _bookRepository.Create(newBook);
                    _bookRepository.SaveChanges();
                    transaction.Commit();

                    return new CreateBookResponse
                    {
                        Id = newBook.BookId,
                        Name = newBook.BookName,
                        Category = new CategoryModel
                        {
                            Id = category.CategoryId,
                            Name = category.CategoryName
                        }
                    };
                }

                return null;
            }
            catch
            {
                transaction.RollBack();

                return null;
            }
        }

        public bool Delete(int id)
        {
            using var transaction = _bookRepository.DatabaseTransaction();

            try
            {
                var book = _bookRepository.Get(book => book.BookId == id);

                if (book != null)
                {
                    _bookRepository.Delete(book);
                    _bookRepository.SaveChanges();
                    transaction.Commit();

                    return true;
                }

                return false;
            }
            catch
            {
                transaction.RollBack();

                return false;
            }
        }

        public IEnumerable<GetBookModel> GetAll()
        {
            var listBooks = _bookRepository.GetAll();

            return listBooks.Select(entity => new GetBookModel
            {
                Id = entity.BookId,
                Name = entity.BookName,
                Category = new CategoryModel
                {
                    Id = entity.Category.CategoryId,
                    Name = entity.Category.CategoryName
                }
            });
        }

        public GetBookModel? GetById(int id)
        {
            var book = _bookRepository.Get(b => b.BookId == id);

            if (book == null)
            {
                return null;
            }

            return new GetBookModel
            {
                Id = book.BookId,
                Name = book.BookName,
                Category = new CategoryModel
                {
                    Id = book.Category.CategoryId,
                    Name = book.Category.CategoryName
                }
            };
        }

        public UpdateBookResponse? Update(int id, UpdateBookRequest updateModel)
        {
            using var transaction = _bookRepository.DatabaseTransaction();

            try
            {
                var book = _bookRepository.Get(b => b.BookId == id);

                if (book != null)
                {
                    var category = _categoryRepository.Get(cat => cat.CategoryId == updateModel.Category.Id);

                    if (category != null)
                    {
                        book.BookName = updateModel.Name;
                        book.CategoryId = updateModel.Category.Id;
                        book.Category = new Category
                        {
                            CategoryId = updateModel.Category.Id,
                            CategoryName = updateModel.Category.Name
                        };

                        _bookRepository.Update(book);
                        _bookRepository.SaveChanges();
                        transaction.Commit();

                        return new UpdateBookResponse
                        {
                            Id = book.BookId,
                            Name = book.BookName,
                            Category = new CategoryModel
                            {
                                Id = book.Category.CategoryId,
                                Name = book.Category.CategoryName
                            }
                        };
                    }
                }

                return null;
            }
            catch
            {
                transaction.RollBack();

                return null;
            }
        }
    }
}
