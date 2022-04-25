using BookStore.Entities;
using BookStore.Infrastructure.Application;
using BookStore.Infrastructure.Test;
using BookStore.Persistence.EF;
using BookStore.Persistence.EF.Books;
using BookStore.Persistence.EF.Categories;
using BookStore.Services.Books;
using BookStore.Services.Books.Contracts;
using BookStore.Services.Categories;
using BookStore.Services.Categories.Contracts;
using BookStore.Test.Tools;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.Services.Test.Unit.Categories
{
    public class BookServiceTests
    {
        private readonly EFDataContext _dataContext;
        private readonly UnitOfWork _unitOfWork;
        private readonly BookService _sut;
        private readonly BookRepository _repository;

        public BookServiceTests()
        {
            _dataContext = new EFInMemoryDatabase()
                .CreateDataContext<EFDataContext>();
            _unitOfWork = new EFUnitOfWork(_dataContext);
            _repository = new EFBookRepository(_dataContext);
            _sut = new BookAppService(_repository, _unitOfWork);
        }

        [Fact]
        public void Add_should_add_books_Properly()
        {
            var category = CategoryServiceTools.GenerateCategory("asd");
            _dataContext.Manipulate(_ => _.Categories.Add(category));
            var dto = BookServiceTools.GenerateAddBookDto(category);

            _sut.Add(dto);
            _dataContext.Books.Should()
                .Contain(_ => _.Title == dto.Title);
        }



        [Fact]
        public void Add_should_throw_wrong_category_if_categoryid_is_wrong()
        {
          
        }
    }


}
