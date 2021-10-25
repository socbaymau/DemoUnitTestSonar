//using Data.Models;
//using DemoProject.Controllers;
//using DemoProject.Models;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using Servers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace UnitTest
//{
//    public class UnitTestController
//    {
//        //[Fact]
//        //public async Task TestView_GetVideosViewModel()
//        //{
//        //    var mockRepo = new Mock<IVideoService>();
//        //    mockRepo.Setup(s => s.GetAll())
//        //        .ReturnsAsync(GetTestSessions());

//        //    var controller = new VideoController(mockRepo.Object);

//        //    // Act
//        //    var result = await controller.GetVideosViewModel();

//        //    // Assert

//        //    Assert.Equal(2, result.Value.Count());
//        //}
//        [Fact]
//        public void TestView_GetVideosViewModel()
//        {
//            var mockRepo = new Mock<IVideoService>();
//            mockRepo.Setup(s => s.GetAll())
//                .Returns(GetTestSessions());

//            var controller = new VideoController(mockRepo.Object);

//            // Act
//            var result = controller.GetVideosViewModel();

//            // Assert

//            Assert.Equal(2, result.Value.Count());
//        }


//        private List<Videos> GetTestSessions()
//        {
//            var sessions = new List<Videos>();
//            sessions.Add(new Videos()
//            {
//                Id = 1,
//                PathName = "Test One"
//            });
//            sessions.Add(new Videos()
//            {
//                Id = 2,
//                PathName = "Test Two"
//            });
//            Console.WriteLine(sessions);
//            return sessions;
//        }
//    }
//}
