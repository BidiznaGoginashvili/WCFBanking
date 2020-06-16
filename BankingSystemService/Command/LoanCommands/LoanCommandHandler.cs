using System;
using BankingSystemService.Result;
using Banking.Domain.LoanManagement;
using Banking.Domain.UserManagement;
using Banking.Infrastructure.Repository;

namespace BankingSystemService.Command.LoanCommands
{
    public class LoanCommandHandler :
        IRequestHandler<CreateLoanCommand, CommandResult<Loan>>
    {
        public static Repository<User> repository = new Repository<User>();
        public static Repository<Loan> loanRepository = new Repository<Loan>();

        public CommandResult<Loan> Handle(CreateLoanCommand request)
        {
            try
            {
                var loan = new Loan(request.Amount, request.MonthlyPay, request.StartDate, request.FinishDate);
                if (request.UserId > 0)
                {
                    var user = repository.GetById(request.UserId);
                    if (user != null)
                    {
                        loan.UserId = request.UserId;
                        loan.User = repository.GetById(request.UserId);
                    }
                }

                loanRepository.Insert(loan);

                return new CommandResult<Loan>
                {
                    Success = true
                };
            }
            catch (Exception exception)
            {
                return new CommandResult<Loan>
                {
                    Success = false,
                    Exception = exception
                };
            }
        }
    }
}