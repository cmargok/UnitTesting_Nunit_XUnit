using Base.Fundamentals;

namespace NUnit.TestingBase
{
    [TestFixture]
    public class StackTest
    {
        private StackY<string> _stack;


        [SetUp]
        public void SetUp()
        {
            _stack = new StackY<string>();
        }



        [Test]
        public void Push_ObjectIsNull_ThrowArgumentNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }


        [Test]
        [TestCase("agua")]
        [TestCase("fuego")]
        [TestCase("tierra")]
        [TestCase("aire")]
        public void Push_WhenIsCalled_AddsTheObjectToStack(string Obj)
        {
            _stack.Push(Obj);

            var result = _stack.Peek();

            Assert.That(result, Is.EqualTo(Obj));
            Assert.That(_stack.Count, Is.EqualTo(1));
        }





        [Test]
        public void Pop_StackIsEmpty_ThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }


        [Test]
        [TestCase("agua", "fuego", "tierra", "aire")]
        [TestCase("aire", "agua", "fuego", "tierra")]
        [TestCase("tierra", "aire", "agua", "fuego")]
        [TestCase("fuego", "tierra", "aire", "agua")]
        public void Pop_TakeAndDeleteLastObjectAddedToTheStack_ReturnsLastObjectAdded(string a, string b, string c, string d)
        {
            _stack.Push(a);
            _stack.Push(b);
            _stack.Push(c);
            _stack.Push(d);

            var result = _stack.Pop();
            var newLastObject = _stack.Peek();

            Assert.That(result, Is.EqualTo(d));
            Assert.That(newLastObject, Is.EqualTo(c));
        }





        [Test]
        public void Peek_StackIsEmpty_ThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }


        [Test]
        [TestCase("agua", "fuego", "tierra", "aire")]
        [TestCase("aire", "agua", "fuego", "tierra")]
        [TestCase("tierra", "aire", "agua", "fuego")]
        [TestCase("fuego", "tierra", "aire", "agua")]
        public void Peek_VerifyLastObjectAddedToTheStack_ReturnsLastObjectAdded(string a, string b, string c, string d)
        {
            _stack.Push(a);
            _stack.Push(b);
            _stack.Push(c);
            _stack.Push(d);

            var result = _stack.Peek();

            Assert.That(result, Is.EqualTo(d));
        }




    }

}
