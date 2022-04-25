using BookStore.Entities;
using BookStore.Services.Categories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Test.Tools
{
    public static class CategoryServiceTools
    {
        public static Category GenerateCategory(string title)
        {
            return new Category
            {
                Title = title
            };
        }
        public static AddCategoryDto GenerateAddCategoryDto(string title)
        {
            return new AddCategoryDto
            {
                Title = title
            };
        }
        public static UpdateCategoryDto GenerateUpdateCategoryDto(string title)
        {
            return new UpdateCategoryDto
            {
                Title = title
            };
        }

    }
}
