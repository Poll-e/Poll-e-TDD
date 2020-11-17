using System;
using System.Text.RegularExpressions;
using NUnit.Framework;
using PollE.Controllers.DTOs;
using PollE.DataAccess.DataService;

namespace PollETests.ServiceTests
{
    [TestFixture]
    public class PollServiceTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        private IPollService pollService;

        [Test]
        public void TestCreate()
        {
            //Arrange
            var poll = new PollCreate
            {
                Category = "Category",
                Title = "Title"
            };


            //Act
            var result = pollService.CreatePoll(poll).Result;

            //Assert
            Assert.IsTrue(new Regex("\\d*").IsMatch(result.Code));
        }

        [Test]
        public void TestGetExisting()
        {
            //Arrange
            var code = "123456789";

            //Act
            var result = pollService.GetPollByCode("code").Result;

            //Assert
            Assert.IsNotNull(result);
        }


        [Test]
        public void TestGetNonExistent()
        {
            //Arrange
            var code = "123456789";

            try
            {
                //Act
                var result = pollService.GetPollByCode("code");
            }
            catch (Exception e)
            {
                Assert.Pass();
                return;
            }

            Assert.Fail();
        }
    }
}