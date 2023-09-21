using Base.Mocking;
using Moq;

namespace NUnit.TestingBase.Mocking
{
    [TestFixture]
    public class OrderServiceTest
    {
        private Mock<IStorage> _storage;
        private OrderService _orderService;
        [SetUp]
        public void SetUp()
        {
            _storage = new Mock<IStorage>();
            _orderService = new OrderService(_storage.Object);
        }


        [Test]
        public void PlaceOrder_()
        {
            var order = new Order();
            _orderService.PlaceOrder(order);


            _storage.Verify(s => s.Store(order));
        }
    }
}
