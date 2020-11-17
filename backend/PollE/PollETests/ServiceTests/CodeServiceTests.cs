using System.Text.RegularExpressions;
using NUnit.Framework;
using PollE.DataAccess.DataService;

namespace PollETests.ServiceTests
{
    [TestFixture]
    public class CodeServiceTests
    {
        [SetUp]
        public void SetUp()
        {
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