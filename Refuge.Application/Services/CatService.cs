using Refuge.Application.Abstractions.Repositories;
using Refuge.Application.Abstractions.Services;
using Refuge.Application.Entities;
using Refuge.Application.Enums;

namespace Refuge.Application.Services
{
    public class CatService(ICatRepository catRepository)
        : ICatService
    {
        public Cat Add(Cat cat)
        {
            return catRepository.Add(cat);
        }

        public Cat Delete(int id)
        {
            Cat cat = catRepository.FindOne(id) 
                ?? throw new KeyNotFoundException();
            catRepository.Remove(cat);
            return cat;
        }

        public Cat FindById(int id)
        {
            return catRepository.FindOne(id)
                ?? throw new KeyNotFoundException();
        }

        public List<Cat> SearchByLetterAndColor(char letter, CatColor color)
        {
            return catRepository.FindWhere(c =>
                c.Name.Contains(letter.ToString()) 
                && c.Color == color
            );
        }

        public Cat Update(int id, Cat cat)
        {
            Cat c = catRepository.FindOne(id)
                ?? throw new KeyNotFoundException();
            c.Name = cat.Name;
            c.Color = cat.Color;
            catRepository.Update(c);
            return c;
        }
    }
}
