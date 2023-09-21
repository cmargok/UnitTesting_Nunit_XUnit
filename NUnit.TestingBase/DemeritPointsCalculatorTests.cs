using Base.Fundamentals;

namespace NUnit.TestingBase
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new DemeritPointsCalculator();
        }

        [Test]
        public void CalculateDemeritPoints_SpeedIslessOrEqualThanLimit_return0()
        {
            var result = _calculator.CalculateDemeritPoints(50);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateDemeritPoints_SpeedIsNegative_ThrowArgumentOutOfRangeException()
        {
            Assert.That(() => _calculator.CalculateDemeritPoints(-1), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CalculateDemeritPoints_SpeedIsGreaterThanMaxSpeed_ThrowArgumentOutOfRangeException()
        {
            Assert.That(() => _calculator.CalculateDemeritPoints(301), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CalculateDemeritPoints_SpeedIsHigherThanSpeedLimitButLowerThanMaxSpeed_ReturnsDemeritsPoints()
        {
            var CurrentSpeed = 80;

            var result = _calculator.CalculateDemeritPoints(CurrentSpeed);

            Assert.That(result, Is.EqualTo((CurrentSpeed - 65) / 5));
        }

    }



}
