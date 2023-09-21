using Base.Mocking;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestingBase.Mocking
{
   
    [TestFixture]
    public class VideoServiceTest
    {
        private Mock<IFileReader> _fileReader;
        private VideoService _videoService;
        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _videoService = new VideoService(_fileReader.Object);
        }


        [Test]
        public void ReadVideoTitle()
        {
            var path = "video.txt";

            _fileReader.Setup(f => f.Read(path)).Returns("");

            var result = _videoService.ReadVideoTitle(path);

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
