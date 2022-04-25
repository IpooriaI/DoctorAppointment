using BookStore.Entities;
using BookStore.Infrastructure.Application;

namespace BookStore.Services.Books.Contracts
{
    public interface BookRepository : Repository
    {
        void Add(Book book);
    }
}
