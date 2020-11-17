using NUnit.Framework;
using PollE.DataAccess.Repositories;

namespace PollETests.RepositoryTests
{
    [TestFixture]
    public class CodeRepositoryTests
    {
        [SetUp]
        public void SetUp()
        {
            //Create codeRepository
        }

        private ICodeRepository codeRepository;

        [Test]
        public void CanSaveCode()
        {
            //Arrange
            var code = "123456789";

            //Act
            var result = codeRepository.InsertCodeAsync("").Result;

            //Assert

            Assert.AreEqual(code, result.Code);
        }
    }
}