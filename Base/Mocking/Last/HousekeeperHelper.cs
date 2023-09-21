namespace Base.Mocking.Last
{
    public class HousekeeperHelper
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStatementGenerartor _statementGenerartor;
        private readonly IEmailSender _emailSender;
        private readonly IXtraMessageBox _xtraMessageBox;

        public HousekeeperHelper(
            IUnitOfWork unitOfWork,
            IStatementGenerartor statementGenerartor,
            IEmailSender emailSender,
            IXtraMessageBox xtraMessageBox)
        {
            _unitOfWork = unitOfWork;
            _statementGenerartor = statementGenerartor;
            _emailSender = emailSender;
            _xtraMessageBox = xtraMessageBox;
        }


        public bool SendStatementEmails(DateTime statementDate)
        {
            var housekeepers = _unitOfWork.Query<Housekeeper>();

            foreach (var housekeeper in housekeepers)
            {
                if (string.IsNullOrWhiteSpace(housekeeper.Email))
                    continue;

                var statementFilename = _statementGenerartor.SaveStatement(housekeeper.Oid, housekeeper.FullName, statementDate);

                if (string.IsNullOrWhiteSpace(statementFilename))
                    continue;

                var emailAddress = housekeeper.Email;
                var emailBody = housekeeper.StatementEmailBody;

                try
                {
                    _emailSender.EmailFile(emailAddress, emailBody, statementFilename,
                        string.Format("Sandpiper Statement {0:yyyy-MM} {1}", statementDate, housekeeper.FullName));
                }
                catch (Exception e)
                {
                    _xtraMessageBox.Show(e.Message, string.Format("Email failure: {0}", emailAddress),
                        MessageBoxButtons.OK);
                }
            }

            return true;
        }




    }











}
