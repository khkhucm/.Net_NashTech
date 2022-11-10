using Test.Data.Entities;
using Test.Data.Repositories.Interfaces;
using TestWebAPI.DTOs.Book;
using TestWebAPI.DTOs.Category;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBookRepository _bookRepository;

        public CategoryService(ICategoryRepository categoryRepository, IBookRepository bookRepository)
        {
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
        }

        public CreateCategoryResponse? Create(CreateCategoryRequest addModel)
        {
            using var transaction = _categoryRepository.DatabaseTransaction();

            try
            {
                var categoryIsExist = _categoryRepository.Get(c => c.CategoryName.ToLower() == addModel.Name.Trim().ToLower());

                if (categoryIsExist == null)
                {
                    var newCategory = new Category
                    {
                        CategoryName = addModel.Name,
                        IsDeleted = false,
                    };

                    _categoryRepository.Create(newCategory);
                    _categoryRepository.SaveChanges();
                    transaction.Commit();

                    return new CreateCategoryResponse
                    {
                        Id = newCategory.CategoryId,
                        Name = newCategory.CategoryName,
                    };
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                transaction.RollBack();

                return null;
            }
        }

        public bool Delete(int id)
        {
            using var transaction = _categoryRepository.DatabaseTransaction();
            try
            {
                var category = _categoryRepository.Get(cat => cat.CategoryId == id);

                if (category != null)
                {
                    _categoryRepository.Delete(category);
                    _categoryRepository.SaveChanges();
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

        public IEnumerable<GetCategoryModel> GetAll()
        {
            var listCategories = _categoryRepository.GetAll(c => c.IsDeleted == false);

            return listCategories
                .Select(entity => new GetCategoryModel
                {
                    Id = entity.CategoryId,
                    Name = entity.CategoryName,
                    Books = _bookRepository
                        .GetAll(b => b.IsDeleted == false)
                        .Where(b => b.CategoryId == entity.CategoryId)
                        .Select(e => new BookModel
                        {
                            Id = e.BookId,
                            Name = e.BookName
                        }),
                });
        }

        public GetCategoryModel? GetById(int id)
        {
            var category = _categoryRepository.Get(c => c.CategoryId == id && c.IsDeleted == false);

            if (category == null)
            {
                return null;
            }

            return new GetCategoryModel
            {
                Id = category.CategoryId,
                Name = category.CategoryName,
                Books = _bookRepository
                        .GetAll(b => b.IsDeleted == false)
                        .Where(b => b.CategoryId == id)
                        .Select(e => new BookModel
                        {
                            Id = e.BookId,
                            Name = e.BookName
                        }),
            };
        }

        public bool SoftDelete(int id)
        {
            using var transaction = _categoryRepository.DatabaseTransaction();

            try
            {
                var category = _categoryRepository.Get(c => c.CategoryId == id && c.IsDeleted == false);

                if (category != null)
                {
                    category.IsDeleted = true;
                    _categoryRepository.Update(category);
                    _categoryRepository.SaveChanges();
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

        public UpdateCategoryResponse? Update(int id, UpdateCategoryRequest updateModel)
        {
            using var transaction = _categoryRepository.DatabaseTransaction();
            try
            {
                var category = _categoryRepository.Get(c => c.CategoryId == id);

                if (category != null)
                {
                    category.CategoryName = updateModel.Name;

                    _categoryRepository.Update(category);
                    _categoryRepository.SaveChanges();
                    transaction.Commit();

                    return new UpdateCategoryResponse
                    {
                        Id = category.CategoryId,
                        Name = category.CategoryName
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
    }
}
