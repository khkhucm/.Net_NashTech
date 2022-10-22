using Assignment02.DTOs.Product;
using Assignment02.Models;
using Assignment02.Repositories;

namespace Assignment02.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _cateRepository;

        public ProductService(IProductRepository repository, ICategoryRepository categoryRepository)
        {
            _repository = repository;
            _cateRepository = categoryRepository;
        }

        public AddProductResponse? Add(AddProductRequest addModel)
        {
            using (var _trancsation = _repository.DatabaseTransaction())
            {
                try
                {
                    var category = _cateRepository.Get(cat => cat.Id == addModel.CategoryId);

                    if (category != null)
                    {
                        var addProduct = new Product
                        {
                            ProductName = addModel.ProductName,
                            Manufacture = addModel.Manufacture,
                            CategoryId = category.Id
                        };

                        var newProduct = _repository.Create(addProduct);

                        _repository.SaveChanges();

                        _trancsation.Commit();

                        return new AddProductResponse
                        {
                            ProductId = newProduct.Id,
                            ProductName = newProduct.ProductName,
                            CategoryId = newProduct.CategoryId,
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

        public ProductViewModel? Delete(int id)
        {
            using (var _trancsation = _repository.DatabaseTransaction())
            {
                try
                {
                    var product = _repository.Get(p => p.Id == id);
                    if (product != null)
                    {
                        var deleteProduct = _repository.Delete(product);

                        _repository.SaveChanges();

                        _trancsation.Commit();

                        return new ProductViewModel
                        {
                            ProductId = product.Id,
                            ProductName = product.ProductName,
                            CategoryId = product.CategoryId
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

        public IEnumerable<ProductViewModel> GetAll()
        {
            var products = _repository.GetAll(x => true);

            List<ProductViewModel> viewModels = new List<ProductViewModel>();
            foreach (var i in products)
            {
                viewModels.Add(new ProductViewModel
                {
                    ProductId = i.Id,
                    ProductName = i.ProductName,
                    CategoryId = i.CategoryId
                });
            }

            return viewModels;
        }

        public ProductViewModel? GetById(int id)
        {
            var product = _repository.Get(p => p.Id == id);

            ProductViewModel viewModel = new ProductViewModel
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                CategoryId = product.CategoryId
            };

            return viewModel;
        }

        public UpdateProductResponse? Update(int id, UpdateProductRequest updateModel)
        {
            using (var _trancsation = _repository.DatabaseTransaction())
            {
                try
                {
                    var product = _repository.Get(p => p.Id == id);
                    if (product != null)
                    {
                        var category = _cateRepository.Get(cat => cat.Id == updateModel.CategoryId);
                        if (category != null)
                        {
                            product.ProductName = updateModel.ProductName;
                            product.CategoryId = updateModel.CategoryId;
                            product.Manufacture = updateModel.Manufacture;

                            var updateProduct = _repository.Update(product);

                            _repository.SaveChanges();

                            _trancsation.Commit();

                            return new UpdateProductResponse
                            {
                                ProductId = product.Id,
                                ProductName = product.ProductName,
                                CategoryId = product.CategoryId
                            };
                        }
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
    }
}