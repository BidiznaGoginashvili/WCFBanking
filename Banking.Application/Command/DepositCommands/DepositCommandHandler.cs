using System;
using System.Linq;
using Banking.Application.Result;
using Banking.Domain.UserManagement;
using Banking.Infrastructure.DataBase;
using Banking.Domain.DepositManagement;
using Banking.Infrastructure.Repository;

namespace Banking.Application.Command.DepositCommands
{
    public class DepositCommandHandler :
        IRequestHandler<CreateDepositCommand, CommandResult>
    {
        public BankingContext context;
        public DepositCommandHandler()
        {
            context = new BankingContext();
        }
        public static Repository<User> repository = new Repository<User>();
        public static Repository<Deposit> depositRepository = new Repository<Deposit>();

        public CommandResult Handle(CreateDepositCommand request)
        {
            try
            {
                if (request.UserId > 0)
                {
                    var deposit = new Deposit(request.Balance, request.MonthlyPay);
                    var user = context.User.SingleOrDefault(us => us.Id == request.UserId);
                    if (user != null)
                    { 
                        deposit.User = repository.GetById(request.UserId);
                    }

                    depositRepository.Insert(deposit);

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