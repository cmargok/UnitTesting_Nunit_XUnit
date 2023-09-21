using Base.Mocking;
using Base.Mocking.Last;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestingBase.Mocking.HouseKeeperelper
{
    [TestFixture]
    public class HouseKeeperTests
    {
        private HousekeeperHelper _service;

        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IStatementGenerartor> _statementGenerartor;
        private Mock<IEmailSender> _emailSender;
        private Mock<IXtraMessageBox> _messageBox;

        private DateTime _statementDate = new DateTime(2017, 1, 1);
        private Housekeeper _housekeeper;
        private string _statmentFileName = "filename";

        [SetUp]
        public void SetUp()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _housekeeper = new Housekeeper()
            {
                Email = "a",
                FullName = "b",
                Oid = 1,
                StatementEmailBody = "c",
            };
            _unitOfWork.Setup(uow => uow
                .Query<Housekeeper>())
                .Returns(new List<Housekeeper> { _housekeeper }.AsQueryable());

            _statementGenerartor = new Mock<IStatementGenerartor>();
            _emailSender = new Mock<IEmailSender>();
            _messageBox = new Mock<IXtraMessageBox>();

            _service = new HousekeeperHelper(
               _unitOfWork.Object,
               _statementGenerartor.Object,
               _emailSender.Object,
               _messageBox.Object);

        }

        [Test]
        public void SendStatementEmails_WhenCalled_GenerateStaments()
        {
            _service.SendStatementEmails(_statementDate);

            _statementGenerartor.Verify(sg =>
            sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate));
        }


        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SendStatementEmails_HouseKeeperEmailIsNullOrEmptyOrWhiteSpace_ShouldNotGenerateStaments(string email)
        {
            _housekeeper.Email = email;

            _service.SendStatementEmails(_statementDate);

            _statementGenerartor.Verify(sg =>
            sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate),
            Times.Never);
        }



        [Test]
        public void SendStatementEmails_WhenCalled_EmailTheStatement()
        {
            _statementGenerartor
                .Setup(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate))
                .Returns(_statmentFileName);

            _service.SendStatementEmails(_statementDate);

            _emailSender.Verify(es =>
                es.EmailFile(
                    _housekeeper.Email,
                    _housekeeper.StatementEmailBody,
                    _statmentFileName,
                     //string.Format("Sandpiper Statement {0:yyyy-MM} {1}", _statementDate, _housekeeper.FullName)));
                     It.IsAny<string>()));

        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SendStatementEmails_HouseKeeperStatementFileNameIsNullOrEmptyOrWhiteSpace_ShouldNotEmailStaments(string email)
        {
            _statementGenerartor
                 .Setup(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate))
                 .Returns(() => null);

            _service.SendStatementEmails(_statementDate);

            _emailSender.Verify(es =>
           es.EmailFile(
               It.IsAny<string>(),
               It.IsAny<string>(),
               It.IsAny<string>(),
               It.IsAny<string>()),
            Times.Never);
        }


        [Test]
        public void SendStatementEmails_EmailSendingFails_DisplayAMessageBox()
        {
            _statementGenerartor
                .Setup(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate))
                .Returns(_statmentFileName);

            _emailSender.Setup(es => es.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()
            )).Throws<Exception>();

            _service.SendStatementEmails(_statementDate);

            _messageBox.Verify(mb =>
             mb.Show(
                 It.IsAny<string>(),
                 It.IsAny<string>(),
                 MessageBoxButtons.OK
                 )
             );

        }

    }
}
