using System;
using Banking.Application.Result;
using System.Data.Entity.Validation;
using Banking.Domain.UserManagement;
using Banking.Domain.DepositManagement;
using Banking.Infrastructure.Repository;
using Banking.Application.Extensions;

namespace Banking.Application.Command.DepositCommands
{
    public class DepositCommandHandler :
        IRequestHandler<CreateDepositCommand, CommandResult>
    {
        public static Repository<User> repository = new Repository<User>();
        public static Repository<Deposit> depositRepository = new Repository<Deposit>();

        public CommandResult Handle(CreateDepositCommand request)
        {
            try
            {
                if (request.UserId > 0)
                {
                    var deposit = new Deposit(request.Balance, request.MonthlyPay);
                    var user = repository.GetById(request.UserId);
                    if (user != null)
                    {

                        deposit.UserId = request.UserId;
                        deposit.User = repository.GetById(request.UserId);
                    }


                    depositRepository.Insert(deposit);

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