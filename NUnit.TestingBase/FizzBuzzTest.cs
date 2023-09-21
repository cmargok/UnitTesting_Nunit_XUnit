using Base.Fundamentals;

namespace NUnit.TestingBase
{
    [TestFixture]
    public partial class FizzBuzzTest
    {


        [Test]
        public void GetOuput_NumberCanBeDividedBy3_ReturnFizz()
        {
            var result = FizzBuzz.GetOutput(3);

            Assert.That(result, Is.EqualTo("Fizz"));

        }

        [Test]
        public void GetOuput_NumberCanBeDividedBy5_ReturnBuzz()
        {
            var result = FizzBuzz.GetOutput(5);

            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOuput_NumberCanBeDividedBy3And5_ReturnFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);

            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }


        [Test]
        public void GetOuput_NumberCannotBeDividedBy3Or5_ReturnNumberConvertedIntoAString()
        {
            var result = FizzBuzz.GetOutput(2);

            Assert.That(result, Is.EqualTo("2"));
        }


        [Test]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        [TestCase(4, "4")]
        public void GetOuput_WhenIsCalled_ReturnOutput(int number, string output)
        {
            var result = FizzBuzz.GetOutput(number);

            Assert.That(result, Is.EqualTo(output));
        }
    }



}
