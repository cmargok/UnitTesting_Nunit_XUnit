using Base.Fundamentals;

namespace XUnit.TestingBase
{
    public class FizzBuzzTest
    {
        [Fact]
        public void GetOuput_NumberCanBeDividedBy3_ReturnFizz()
        {
            var result = FizzBuzz.GetOutput(3);

            Assert.Equal("Fizz", result);

        }
        [Fact]
        public void GetOuput_NumberCanBeDividedBy5_ReturnBuzz()
        {
            var result = FizzBuzz.GetOutput(5);

            Assert.Equal("Buzz",result);
        }

        [Fact]
        public void GetOuput_NumberCanBeDividedBy3And5_ReturnFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);

            Assert.Equal("FizzBuzz",result);
        }


        [Fact]
        public void GetOuput_NumberCannotBeDividedBy3Or5_ReturnNumberConvertedIntoAString()
        {
            var result = FizzBuzz.GetOutput(2);

            Assert.Equal("2",result);
        }

        [Theory]
        [InlineData(3, "Fizz")]
        [InlineData(5, "Buzz")]
        [InlineData(15, "FizzBuzz")]
        [InlineData(4, "4")]
        public void GetOuput_WhenIsCalled_ReturnOutput(int number, string output)
        {
            var result = FizzBuzz.GetOutput(number);

            Assert.Equal(output, result);
        }
    }
}