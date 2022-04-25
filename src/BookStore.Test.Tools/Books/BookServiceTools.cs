using BookStore.Entities;
using BookStore.Services.Books.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Test.Tools
{
    public static class BookServiceTools
    {
        public static AddBookDto GenerateAddBookDto(int id)
        {
            return new AddBookDto
            {
                Title = "asd",
                Author = "ali",
                Description = "A new book",
                Pages = 30,
                CategoryId = id
            };
        }
    }
}
