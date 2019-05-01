namespace SoftUniClone.Tests.Web.Controllers.CoursesControllerTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using NUnit.Framework;
    using SoftUniClone.Services.Models.Courses;
    using SoftUniClone.Web.Controllers;
    using SoftUniClone.Web.Models;
    using static Common.Constants;

    public class IndexTests : BaseCoursesControllerTest
    {
        [Test]
        public async Task Index_ShouldReturnViewWithCorrectModel()
        {
            // Arrange
            const int TotalElements = 10;
            var totalPages = TotalElements / CoursePageSize;
            var elements = this.GetCollectionOfElements<CourseBasicServiceModel>(10);

            this.CourseService
                .Setup(cs => cs.GetAllListingAsync("", 1))
                .ReturnsAsync(elements);

            this.CourseService
                .Setup(cs => cs.TotalCountAsync(""))
                .ReturnsAsync(TotalElements);

            // Act
            var result = await this.Controller.Index("", 1) as ViewResult;
            var model = result.ViewData.Model as PagesViewModel<CourseBasicServiceModel>;

            // Assert
            Assert.AreEqual(model.Elements.Count(), TotalElements);
            Assert.AreEqual(model.SearchToken, "");
            Assert.AreEqual(model.Pagination.TotalPages, totalPages);
            Assert.AreEqual(model.Pagination.TotalElements, TotalElements);
            Assert.AreEqual(model.Pagination.PageSize, CoursePageSize);
            Assert.AreEqual(model.Pagination.CurrentPage, 1);
        }

        [Test]
        public async Task Index_ShouldReturnView()
        {
            // Act
            var result = await this.Controller.Index();

            // Assert
            Assert.IsAssignableFrom<ViewResult>(result);
        }

        private IEnumerable<T> GetCollectionOfElements<T>(int count) where T : class
        {
            var list = new List<T>();
            for (int i = 0; i < count; i++)
            {
                list.Add(Activator.CreateInstance<T>());
            }

            return list;
        }
    }
}
