using System;
using System.Text.RegularExpressions;
using Moq;
using NUnit.Framework;
using PollE.Controllers.DTOs;
using PollE.DataAccess.DataService;
using PollE.DataAccess.Entities;
using PollE.DataAccess.Repositories;

namespace PollETests.ServiceTests
{
    [TestFixture]
    public class PollServiceTest
    {
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

            var pollMock = new Mock<IPollRepository>();
            pollMock
                .Setup(x => x.InsertPollAsync(It.IsAny<PollEntity>()));
            var codeMock = new Mock<ICodeService>();
            codeMock.Setup(x => x.GenerateCode())
                .ReturnsAsync(new CodeEntity() {Code = "123456", Id = 1});

            pollService = new PollService(pollMock.Object, codeMock.Object);
            
            //Act
            var result = pollService.CreatePoll(poll).Result;

            //Assert
            Assert.IsTrue(new Regex("\\d*").IsMatch(result.Code));
            codeMock.Verify(x => x.GenerateCode(), Times.Once);
            pollMock.Verify(x => x.InsertPollAsync(It.IsAny<PollEntity>()), Times.Once);
        }

        [Test]
        public void TestGetExisting()
        {
            //Arrange
            var poll = new PollCreate
            {
                Category = "Category",
                Title = "Title"
            };

            var pollMock = new Mock<IPollRepository>();
            pollMock
                .Setup(x => x.GetPollByCodeAsync(It.IsAny<string>()))
                .ReturnsAsync(new PollEntity()
                {
                    Category = new CategoryEntity(){Id = 1, Name = "Category"},
                    Code = new CodeEntity(){Code = "123456", Id = 1},
                    Id = 1,
                    Title = "Title"
                });
            var codeMock = new Mock<ICodeService>();

            pollService = new PollService(pollMock.Object, codeMock.Object);
            
            //Act
            var result = pollService.GetPollByCode("123456").Result;

            //Assert
            Assert.IsNotNull(result);
            pollMock.Verify(x => x.GetPollByCodeAsync(It.IsAny<string>()), Times.Once);
        }


        [Test]
        public void TestGetNonExistent()
        {
            //Arrange
            var pollMock = new Mock<IPollRepository>();
            pollMock
                .Setup(x => x.GetPollByCodeAsync(It.IsAny<string>()))
                .ThrowsAsync(new Exception("Ok"));
            var codeMock = new Mock<ICodeService>();
            pollService = new PollService(pollMock.Object, codeMock.Object);

            try
            {
                //Act
                var result = pollService.GetPollByCode("code").Result;
            }
            catch (Exception e)
            {
                Assert.Pass();
                pollMock.Verify(x => x.GetPollByCodeAsync(It.IsAny<string>()), Times.Once);
                return;
            }

            Assert.Fail();
        }
    }
}