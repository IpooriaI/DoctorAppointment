using BookStore.Services.Books.Contracts;

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
