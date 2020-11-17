using NUnit.Framework;
using PollE.Controllers.DTOs;
using PollE.DataAccess.DataService;

namespace PollETests.IntegrationTests
{
    [TestFixture]
    public class IntegrationTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        private IPollService pollService;

        [Test]
        public void Test()
        {
            //Arrange
            var poll = new PollCreate
            {
                Category = "Category",
                Title = "Title"
            };


            //Act
            var created = pollService.CreatePoll(poll).Result;
            var result = pollService.GetPollByCode(created.Code).Result;

            //Assert
            Assert.AreEqual(poll.Title, result.Title);
            Assert.AreEqual(poll.Category, result.Category);
        }
    }
}