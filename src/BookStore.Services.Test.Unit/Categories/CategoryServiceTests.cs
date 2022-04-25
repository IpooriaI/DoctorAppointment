using BookStore.Entities;
using BookStore.Infrastructure.Application;
using BookStore.Infrastructure.Test;
using BookStore.Persistence.EF;
using BookStore.Persistence.EF.Categories;
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
    public class CategoryServiceTests
    {
        private readonly EFDataContext _dataContext;
        private readonly UnitOfWork _unitOfWork;
        private readonly CategoryService _sut;
        private readonly CategoryRepository _repository;
        
        public CategoryServiceTests()
        {
            _dataContext = new EFInMemoryDatabase()
                .CreateDataContext<EFDataContext>();
            _unitOfWork = new EFUnitOfWork(_dataContext);
            _repository = new EFCategoryRepository(_dataContext);
            _sut = new CategoryAppService(_repository,_unitOfWork);
        }

        [Fact]
        public void Add_adds_category_properly()
        {
            AddCategoryDto dto = CategoryServiceTools
                .GenerateAddCategoryDto("dummyname");

            _sut.Add(dto);

            _dataContext.Categories.Should()
                .Contain(_ => _.Title == dto.Title);
        }

        [Fact]
        public void GetAll_returns_all_categories()
        {
            CreateCategoriesInDataBase();

            var expected = _sut.GetAll();

            expected.Should().HaveCount(3);
            expected.Should().Contain(_ => _.Title == "dummy1");
            expected.Should().Contain(_ => _.Title == "dummy2");
            expected.Should().Contain(_ => _.Title == "dummy3");
        }

        [Fact]
        public void Get_by_id_should_get_the_proper_category()
        {
            CreateCategoriesInDataBase();

            var expected = _sut.GetById(2);

            expected.Id.Should().Be(2);
            expected.Title.Should().Be("dummy2");
        }

        [Fact]
        public void Update_should_update_the_selected_catagory_properly()
        {
            UpdateCategoryDto dto = CategoryServiceTools
                .GenerateUpdateCategoryDto("DummyTest");

            Category category = 
                CategoryServiceTools.GenerateCategory(dto.Title);

            _dataContext.Manipulate(_ => _.Categories.Add(category));

            _sut.Update(category.Id, dto);

            category.Title.Should().Be(dto.Title);
        }

        [Fact]
        public void Delete_Deletes_the_selected_category_properly()
        {
            AddCategoryDto dto = CategoryServiceTools
                .GenerateAddCategoryDto("DummyName");

            Category category = CategoryServiceTools
                .GenerateCategory(dto.Title);

            _dataContext.Manipulate(_ => _.Categories.Add(category));

            _sut.Delete(category.Id);

            var expected = _sut.GetById(category.Id);
            expected.Should().BeNull();
        }





        private void CreateCategoriesInDataBase()
        {
            var categories = new List<Category>
            {
                new Category { Title = "dummy1"},
                new Category { Title = "dummy2"},
                new Category { Title = "dummy3"}
            };
            _dataContext.Manipulate(_ =>
            _.Categories.AddRange(categories));
        }

    }
}
