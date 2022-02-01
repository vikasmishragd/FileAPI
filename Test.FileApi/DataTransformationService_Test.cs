using FileAPI.Entity;
using FileAPI.Repository.Database;
using FileAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Test.FileApi
{
    [TestClass]
    public class DataTransformationService_Test
    {
       private IDataTransformationService dataTransformationService;
        private List<Product> transformedData;
        public DataTransformationService_Test()
        {
            dataTransformationService = new DataTransformationService();
            transformedData = dataTransformationService.TransformCsvToObject(@"..\..\..\Data\iru-assignment-2018.csv");
        }
        [TestMethod]
        public void ReadCSV_TypeCheck_Pass()
        {
            Assert.IsTrue(transformedData is List<Product>);
            Assert.AreEqual(transformedData.Count, 170);
        }

        [TestMethod]
        public void Repository_Create_Pass()
        {
         
            var mockSet = new Mock<DbSet<Product>>();

            var mockContext = new Mock<RepositoryDbContext>();

            var service = new Mock<DBRepository>((mockContext.Object));
            var task = service.Object.Create(transformedData.Take(10).ToList());
            Assert.IsTrue(task.Result);
        }
    }
}
