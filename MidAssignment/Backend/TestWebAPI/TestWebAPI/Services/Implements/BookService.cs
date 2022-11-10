using Common.Enums;
using Test.Data.Entities;
using Test.Data.Repositories.Interfaces;
using TestWebAPI.DTOs.Book;
using TestWebAPI.DTOs.Category;
using TestWebAPI.DTOs.Pagination;
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
                        IsDeleted = false,
                        CategoryId = addModel.CategoryId,
                        Category = category
                    };

                    _bookRepository.Create(newBook);
                    _bookRepository.SaveChanges();
                    transaction.Commit();

                    var categoryModel = new CategoryModel
                    {
                        Id = category.CategoryId,
                        Name = category.CategoryName
                    };

                    if (newBook.Category.IsDeleted == true)
                    {
                        categoryModel = null;
                    }

                    return new CreateBookResponse
                    {
                        Id = newBook.BookId,
                        Name = newBook.BookName,
                        Category = categoryModel
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

        public bool SoftDelete(int id)
        {
            using var transaction = _bookRepository.DatabaseTransaction();

            try
            {
                var book = _bookRepository.Get(book => book.BookId == id);

                if (book != null)
                {
                    book.IsDeleted = true;
                    _bookRepository.Update(book);
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
            var listBooks = _bookRepository.GetAll(b => b.IsDeleted == false);

            return listBooks.Select((entity) =>
            {
                if (entity.Category?.IsDeleted == false)
                {
                    return new GetBookModel
                    {
                        Id = entity.BookId,
                        Name = entity.BookName,
                        Category = new CategoryModel
                        {
                            Id = entity.Category.CategoryId,
                            Name = entity.Category.CategoryName
                        }
                    };
                }
                else
                {
                    return new GetBookModel
                    {
                        Id = entity.BookId,
                        Name = entity.BookName,
                        Category = null
                    };
                }
            });
        }

        public GetBookModel? GetById(int id)
        {
            var book = _bookRepository.Get(b => b.BookId == id && b.IsDeleted == false);

            if (book == null)
            {
                return null;
            }

            var category = new CategoryModel
            {
                Id = book.Category.CategoryId,
                Name = book.Category.CategoryName
            };

            if (book.Category.IsDeleted == true)
            {
                category = null;
            }

            return new GetBookModel
            {
                Id = book.BookId,
                Name = book.BookName,
                Category = category,
            };
        }

        public UpdateBookResponse? Update(int id, UpdateBookRequest updateModel)
        {
            using var transaction = _bookRepository.DatabaseTransaction();

            try
            {
                var book = _bookRepository.Get(b => b.BookId == id && b.IsDeleted == false);

                if (book != null)
                {
                    var category = _categoryRepository.Get(cat => cat.CategoryId == updateModel.Category.Id);

                    if (category != null && category.IsDeleted == false)
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

                        var categoryModel = new CategoryModel
                        {
                            Id = category.CategoryId,
                            Name = category.CategoryName
                        };

                        return new UpdateBookResponse
                        {
                            Id = book.BookId,
                            Name = book.BookName,
                            Category = categoryModel
                        };
                    }
                    else if (category != null && category.IsDeleted == true)
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
                            Category = null,
                        };
                    }
                    else
                    {
                        return null;
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

        public Pagination<GetBookModel> GetPagination(PaginationQueryModel queryModel)
        {
            var books = _bookRepository.GetAll(b => b.IsDeleted == false);

            if (!string.IsNullOrEmpty(queryModel.Name))
            {
                var nameToQuery = queryModel.Name.Trim().ToLower();
                books = books?.Where(b => b.BookName.ToLower().Contains(nameToQuery)).ToList();
            }

            if (queryModel.CategoryId.HasValue)
            {
                var categoryId = queryModel.CategoryId.Value;
                books = books?.Where(x => x.CategoryId == queryModel.CategoryId).ToList();
            }

            queryModel.SortOption ??= SortEnum.NameAcsending;

            switch (queryModel.SortOption.Value)
            {
                case SortEnum.NameAcsending:
                    books = books?.OrderBy(b => b.BookName)?.ToList();
                    break;
                case SortEnum.NameDescending:
                    books = books?.OrderByDescending(b => b.BookName)?.ToList();
                    break;
                case SortEnum.CategoryNameAscending:
                    books = books?.OrderBy(c => c.Category?.CategoryName)?.ToList();
                    break;
                case SortEnum.CategoryNameDescending:
                    books = books?.OrderByDescending(c => c.Category?.CategoryName)?.ToList();
                    break;
                default:
                    break;
            }

            if (books == null || books.Count() == 0)
            {
                queryModel.Page = 1;
                return new Pagination<GetBookModel>
                {
                    Source = null,
                    TotalPage = 1,
                    TotalRecord = 0,
                    QueryModel = queryModel
                };
            }

            var output = new Pagination<GetBookModel>();

            output.TotalRecord = books.Count();

            var listBooks = books.Select((entity) =>
            {
                if (entity.Category?.IsDeleted == false)
                {
                    return new GetBookModel
                    {
                        Id = entity.BookId,
                        Name = entity.BookName,
                        Category = new CategoryModel
                        {
                            Id = entity.Category.CategoryId,
                            Name = entity.Category.CategoryName
                        }
                    };
                }
                else
                {
                    return new GetBookModel
                    {
                        Id = entity.BookId,
                        Name = entity.BookName,
                        Category = null,
                    };
                }
            });

            output.Source = listBooks.Skip((queryModel.Page - 1) * queryModel.PageSize)
                                    .Take(queryModel.PageSize)
                                    .ToList();

            output.TotalPage = (output.TotalRecord - 1) / queryModel.PageSize + 1;

            if (queryModel.Page > output.TotalPage)
            {
                queryModel.Page = output.TotalPage;
            }

            output.QueryModel = queryModel;

            return output;
        }
    }
}
