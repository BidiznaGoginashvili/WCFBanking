using System;
using Banking.Application.Result;
using Banking.Domain.LoanManagement;
using Banking.Domain.UserManagement;
using System.Data.Entity.Validation;
using Banking.Application.Extensions;
using Banking.Infrastructure.Repository;

namespace Banking.Application.Command.LoanCommands
{
    public class LoanCommandHandler :
        IRequestHandler<CreateLoanCommand, CommandResult>
    {
        public static Repository<User> repository = new Repository<User>();
        public static Repository<Loan> loanRepository = new Repository<Loan>();

        public CommandResult Handle(CreateLoanCommand request)
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

                    loanRepository.Insert(loan);
                    return new CommandResult(true);
                }

                return new CommandResult(false, "User not found");
            }
            catch (DbEntityValidationException validations)
            {
                return new CommandResult(false, validations.GetValidations());
            }
            catch (Exception exception)
            {
                return new CommandResult(false, exception.Message);
            }
        }
    }
}