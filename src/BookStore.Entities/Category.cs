using System.Collections.Generic;

namespace BookStore.Entities
{
    public class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public HashSet<Book> Books { get; set; }
    }
}
