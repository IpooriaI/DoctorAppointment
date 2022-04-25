using BookStore.Infrastructure.Application;

namespace BookStore.Services.Books.Contracts
{
    public interface BookService : Service
    {
        void Add(AddBookDto dto);
    }
}
