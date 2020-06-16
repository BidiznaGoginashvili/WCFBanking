using System;
using BankingSystemService.Result;
using Banking.Domain.UserManagement;
using Banking.Domain.DepositManagement;
using Banking.Infrastructure.Repository;

namespace BankingSystemService.Command.DepositCommands
{
    public class DepositCommandHandler :
        IRequestHandler<CreateDepositCommand, CommandResult<Deposit>>
    {
        public static Repository<User> repository = new Repository<User>();
        public static Repository<Deposit> depositRepository = new Repository<Deposit>();

        public CommandResult<Deposit> Handle(CreateDepositCommand request)
        {
            try
            {
                var deposit = new Deposit(request.Balance, request.MonthlyPay);
                if (request.UserId > 0)
                {
                    var user = repository.GetById(request.UserId);
                    if (user != null)
                    {

                        deposit.UserId = request.UserId;
                        deposit.User = repository.GetById(request.UserId);
                    }
                }

                depositRepository.Insert(deposit);

                return new CommandResult<Deposit>
                {
                    Success = true
                };
            }
            catch (Exception exception)
            {
                return new CommandResult<Deposit>
                {
                    Success = false,
                    Exception = exception
                };
            }
        }
    }
}