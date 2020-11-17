using System.Text.RegularExpressions;
using Moq;
using NUnit.Framework;
using PollE.DataAccess.DataService;
using PollE.DataAccess.Entities;
using PollE.DataAccess.Repositories;

namespace PollETests.ServiceTests
{
    [TestFixture]
    public class CodeServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            var mock = new Mock<ICodeRepository>();
                mock.Setup(x => x.InsertCodeAsync(It.IsAny<string>()))
                .ReturnsAsync(new CodeEntity(){Id = 1, Code = "123456"});
            service = new CodeService(mock.Object);
        }

        private ICodeService service;

        [Test]
        public void TestGeneratedCode()
        {
            //Act
            var result = service.GenerateCode().Result;

            //Assert
            Assert.IsTrue(new Regex("\\d*").IsMatch(result.Code));
        }
    }
}