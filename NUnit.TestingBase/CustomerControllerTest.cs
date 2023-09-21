using Base.Fundamentals;

namespace NUnit.TestingBase
{
    [TestFixture]
    public class CustomerControllerTest
    {
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(0);

            Assert.That(result, Is.TypeOf<NotFound>());

            Assert.That(result, Is.InstanceOf<NotFound>());

            Assert.That(result, Is.Not.Null);

        }
    }



}
