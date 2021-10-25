using Data.Models;
using Demo.Data;
using DemoProject.Controllers;
using Microsoft.EntityFrameworkCore;
using Servers;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class UnitTest1
    {
        private readonly VideoStreamingContext context;
        private readonly EfRepository<Videos> _videoRepository;
        private readonly VideoService _videoService;
        public UnitTest1()
        {
            var options = new DbContextOptionsBuilder<VideoStreamingContext>()
                        .UseInMemoryDatabase(databaseName: "TestNewListDb").Options;
            context = new VideoStreamingContext(options);
            _videoRepository = new EfRepository<Videos>(context);
            _videoService = new VideoService(_videoRepository);
        }
        [Fact]
        [Trait("test","value")]
        public void Test()
        {
            var video = new Videos
            {
                PathName = "Test2"
            };

            // 2. Act 
            _videoService.Add(video);
            var result = _videoService.GetAll();
            Assert.NotEmpty(result);
        }

        [Theory]
        [InlineData("Test2")]
        [Trait("test2", "value2")]

        public void TestIsExist(string expectedName)
        {
            var result = _videoService.GetAll();

            // 3. Assert
            Assert.NotEmpty(result.First().PathName);
            Assert.Equal(expectedName, result.First().PathName);

        }

    }

}