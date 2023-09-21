using Base.Fundamentals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace NUnit.TestingBase
{
    [TestClass]
    public class ReservationsTests
    {
        [TestMethod]
        public void CanBeCancelledBy_UserIsNotAllowed_ReturnsFalse()
        {
            // Arrage
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(new User());

            //Assert
            Assert.IsFalse(result);
        }



        [TestMethod]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {

            // Arrage
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(new User() { IsAdmin = true });

            //Assert
            Assert.IsTrue(result);
        }




        [TestMethod]
        public void CanBeCancelledBy_UserIsUserMadeBy_ReturnsTrue()
        {

            // Arrage
            var reservation = new Reservation();

            var User = new User();

            reservation.MadeBy = User;

            // Act
            var result = reservation.CanBeCancelledBy(User);

            //Assert
            Assert.IsTrue(result);
        }
    }

}
