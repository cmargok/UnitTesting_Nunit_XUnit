using Base.Fundamentals;

namespace NUnit.TestingBase
{
    [TestFixture]
    public class ErrorLoggerTest
    {

        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            var logger = new ErrorLogger();

            logger.Log("az");

            Assert.That(logger.LastError, Is.EqualTo("az"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            var logger = new ErrorLogger();


            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);

            //   Assert.That(() => logger.Log(error), Throws.Exception.TypeOf<ArgumentNullException>());
        }
    }



}
