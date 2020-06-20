using System;
using System.Linq;
using Banking.Application.Result;
using Banking.Domain.LoanManagement;
using Banking.Infrastructure.DataBase;
using Banking.Infrastructure.Repository;

namespace Banking.Application.Command.LoanCommands
{
    public class LoanCommandHandler :
        IRequestHandler<CreateLoanCommand, CommandResult>
    {
        public BankingContext context;
        public LoanCommandHandler()
        {
            context = new BankingContext();
        }

        public static Repository<Loan> loanRepository = new Repository<Loan>();
        public static Repository<Guarantor> guarantorRepository = new Repository<Guarantor>();


        public CommandResult Handle(CreateLoanCommand request)
        {
            try
            {
                var user = context.User.SingleOrDefault(us => us.Id == request.UserId);
                var loan = new Loan(request.Amount, request.MonthlyPay, request.StartDate, request.FinishDate);

                if (user != null)
                {
                    var guarantor = new Guarantor(request.GuarantorFirstName, request.GuarantorLastName, request.Phone, request.Relationship);
                    guarantorRepository.Insert(guarantor);

                    loan.Guarantor = guarantor;
                    loan.User = user;

                    loanRepository.Insert(loan);
                    
                    return new CommandResult(true);
                }

                return new CommandResult(false, "User not found");
            }
            catch (Exception exception)
            {
                return new CommandResult(false, exception.Message);
            }
        }
    }
}