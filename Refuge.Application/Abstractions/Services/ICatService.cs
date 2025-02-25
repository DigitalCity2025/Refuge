using Refuge.Application.Entities;
using Refuge.Application.Enums;

namespace Refuge.Application.Abstractions.Services
{
    public interface ICatService
    {
        List<Cat> SearchByLetterAndColor(char letter, CatColor color);
        Cat FindById(int id);
        Cat Add(Cat cat);
        Cat Update(int id, Cat cat);
        Cat Delete(int id);
    }
}
