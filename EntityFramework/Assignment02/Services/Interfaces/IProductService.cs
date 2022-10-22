using Assignment02.DTOs.Product;

namespace Assignment02.Services
{
    public interface IProductService
    {
        AddProductResponse? Add(AddProductRequest addModel);
        IEnumerable<ProductViewModel> GetAll();
        ProductViewModel? GetById(int id);
        UpdateProductResponse? Update(int id, UpdateProductRequest updateModel);
        ProductViewModel? Delete(int id);
    }
}