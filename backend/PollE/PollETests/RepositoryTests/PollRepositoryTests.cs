using NUnit.Framework;
using PollE.DataAccess.Entities;
using PollE.DataAccess.Repositories;

namespace PollETests.RepositoryTests
{
    [TestFixture]
    public class PollRepositoryTests
    {
        [SetUp]
        public void SetUp()
        {
            pollRepository = new InMemoryPollRepository();
        }

        private IPollRepository pollRepository;

        [Test]
        public void CanSaveAndLoadPoll()
        {
            //Arrange
            var poll = new PollEntity
            {
                Category = new CategoryEntity
                {
                    Id = 1,
                    Name = "Category"
                },
                Code = new CodeEntity
                {
                    Code = "1234",
                    Id = 1
                },
                Title = "Title",
                Id = 1
            };

            //Act
            pollRepository.InsertPollAsync(poll).Wait();
            var result = pollRepository.GetPollByCodeAsync(poll.Code.Code).Result;

            //Assert
            Assert.AreEqual(poll.Title, result.Title);
            Assert.AreEqual(poll.Category, result.Category);
        }

        [Test]
        public void CanSavePoll()
        {
            //Arrange
            var poll = new PollEntity
            {
                Category = new CategoryEntity
                {
                    Id = 1,
                    Name = "Category"
                },
                Code = new CodeEntity
                {
                    Code = "1234",
                    Id = 1
                },
                Title = "Title",
                Id = 1
            };

            //Act
            pollRepository.InsertPollAsync(poll).Wait();

            //Assert
            Assert.Pass();
        }
    }
}