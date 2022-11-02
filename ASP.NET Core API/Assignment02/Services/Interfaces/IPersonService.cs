using Assignment02.Models;
using Assignment02.Utils;

namespace Assignment02.Services.Interfaces
{
    public interface IPersonService
    {
        IEnumerable<PersonModel> GetAll(string? name, string? gender, string? birthPlace, int page);
        public PersonModel? GetOne(Guid id);
        PersonModel? Create(PersonCreateModel createModel);
        PersonModel? Update(Guid id, PersonUpdateModel updateModel);
        bool Delete(Guid id);
    }
}