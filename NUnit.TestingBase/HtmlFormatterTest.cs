using Base.Fundamentals;

namespace NUnit.TestingBase
{
    [TestFixture]
    public class HtmlFormatterTest
    {

        [Test]
        public void FormateAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {

            var formatter = new HtmlFormatter();

            var result = formatter.FormatAsBold("abc");


            //Specific
            Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase);


            //More General
            Assert.That(result, Does.StartWith("<strong>"));
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("abc"));
        }
    }



}
