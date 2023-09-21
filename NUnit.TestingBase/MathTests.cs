using mike = Base.Fundamentals;
namespace NUnit.TestingBase
{
    [TestFixture]
    public class MathTests
    {
        private mike.Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new mike.Math();
        }


        //[Test]
        //public void Add_WhenCalled_ReturnTheSumeOfArguments()
        //{      
        //    var result = _math.Add(1, 2);

        //    Assert.That(result, Is.EqualTo(3));
        //}

        [Test]
        [TestCase(3, 1, 3)]
        [TestCase(2, 10, 10)]
        [TestCase(5, 5, 5)]
        public void Max_WhenCalled_ReturnsTheGreaterArgument(int a, int b, int expectedResult)
        {

            var result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        // [Ignore("Pues porque yo lo decidi")]
        public void Max_SecondArgumentIsGreater_ReturnsTheSecondArgument()
        {

            var result = _math.Max(1, 2);

            Assert.That(result, Is.EqualTo(2));
        }


        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            //too general
            Assert.That(result, Is.Not.Empty);

            //more specific
            Assert.That(result.Count, Is.EqualTo(3));

            //specific
            //Assert.That(result.Count, Does.Contain(1));
            //Assert.That(result.Count, Does.Contain(3));
            //Assert.That(result.Count, Does.Contain(5));

            //more specific
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 })); //prefer to assert 

            //more assertions
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);

        }





    }

}
