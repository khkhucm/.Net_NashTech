using Assignment02.DTOs.Category;
using Assignment02.Models;
using Assignment02.Repositories;

namespace Assignment02.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public AddCategoryResponse? Add(AddCategoryRequest addModel)
        {
            using (var _trancsation = _repository.DatabaseTransaction())
            {
                try
                {
                    var addCategory = new Category
                    {
                        CategoryName = addModel.CategoryName
                    };

                    var newProduct = _repository.Create(addCategory);

                    _repository.SaveChanges();

                    _trancsation.Commit();

                    return new AddCategoryResponse
                    {
                        CategoryId = newProduct.Id,
                        CategoryName = newProduct.CategoryName
                    };
                }
                catch
                {
                    _trancsation.RollBack();

                    return null;
                }
            }
        }

        public CategoryViewModel? Delete(int id)
        {
            using (var _trancsation = _repository.DatabaseTransaction())
            {
                try
                {
                    var category = _repository.Get(p => p.Id == id);
                    if (category != null)
                    {
                        var deleteProduct = _repository.Delete(category);

                        _repository.SaveChanges();

                        _trancsation.Commit();

                        return new CategoryViewModel
                        {
                            CategoryId = category.Id,
                            CategoryName = category.CategoryName
                        };
                    }
                    return null;
                }
                catch
                {
                    _trancsation.RollBack();

                    return null;
                }
            }
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            var categories = _repository.GetAll(x => true);

            List<CategoryViewModel> viewModels = new List<CategoryViewModel>();
            foreach (var i in categories)
            {
                viewModels.Add(new CategoryViewModel
                {
                    CategoryId = i.Id,
                    CategoryName = i.CategoryName
                });
            }

            return viewModels;
        }

        public CategoryViewModel? GetById(int id)
        {
            var category = _repository.Get(p => p.Id == id);

            CategoryViewModel viewModel = new CategoryViewModel
            {
                CategoryId = category.Id,
                CategoryName = category.CategoryName
            };

            return viewModel;
        }

        public UpdateCategoryResponse? Update(int id, UpdateCategoryRequest updateModel)
        {
            using (var transaction = _repository.DatabaseTransaction())
            {
                try
                {
                    var category = _repository.Get(c => c.Id == id);

                    if (category != null)
                    {
                        category.CategoryName = updateModel.CategoryName;

                        var updatedCategory = _repository.Update(category);

                        _repository.SaveChanges();

                        transaction.Commit();

                        return new UpdateCategoryResponse
                        {
                            CategoryId = updatedCategory.Id,
                            CategoryName = updatedCategory.CategoryName
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
}