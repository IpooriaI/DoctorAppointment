using BookStore.Entities;
using BookStore.Infrastructure.Application;
using System.Collections.Generic;

namespace BookStore.Services.Categories.Contracts
{
    public interface CategoryService : Service
    {
        void Add(AddCategoryDto dto);
        Category GetById(int id);
        IList<GetCategoryDto> GetAll();
        void Update(int id, UpdateCategoryDto dto);
        void Delete(int id);
    }
}
