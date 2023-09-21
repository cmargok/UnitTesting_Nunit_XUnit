using Base.Fundamentals;

namespace XUnit.TestingBase
{
    public class HtmlFormatterTest
    {
        [Fact]
        public void FormateAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            // Arrange
            var formatter = new HtmlFormatter();

            // Act
            var result = formatter.FormatAsBold("abc");

            // Assert
            // Specific
            Assert.Equal("<strong>abc</strong>", result, ignoreCase: true);

            // More General
            Assert.StartsWith("<strong>", result);
            Assert.EndsWith("</strong>", result);
            Assert.Contains("abc", result);
        }
    }
}
