using Test.Data.Entities;
using TestWebAPI.DTOs.Book;
using TestWebAPI.DTOs.Pagination;

namespace TestWebAPI.Services.Interfaces
{
    public interface IBookService
    {
        CreateBookResponse? Create(CreateBookRequest addModel);
        IEnumerable<GetBookModel> GetAll();
        GetBookModel? GetById(int id);
        UpdateBookResponse? Update(int id, UpdateBookRequest updateModel);
        bool Delete(int id);
        bool SoftDelete(int id);
        Pagination<GetBookModel> GetPagination(PaginationQueryModel queryModel);
    }
}
