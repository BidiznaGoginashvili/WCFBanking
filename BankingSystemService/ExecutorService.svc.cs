using System.Collections.Generic;
using Banking.Application.Result;
using Banking.Domain.UserManagement;
using Banking.Application.Query.UserQueries;
using Banking.Application.Command.LoanCommands;
using Banking.Application.Command.UserCommands;
using Banking.Application.Command.DepositCommands;

namespace BankingSystemService
{
    public class ExecutorService : IExecutorService
    {
        #region Deposit

        public CommandResult Execute(CreateDepositCommand command)
        {
            var handler = new DepositCommandHandler();
            return handler.Handle(command);
        }

        #endregion

        #region Loan

        public CommandResult Execute(CreateLoanCommand command)
        {
            var handler = new LoanCommandHandler();
            return handler.Handle(command);
        }

        #endregion

        #region User

        public CommandResult Execute(RegisterUserCommand command)
        {
            var handler = new UserCommandHandler();
            return handler.Handle(command);
        }

        public CommandResult Execute(LoginUserCommand command)
        {
            var handler = new UserCommandHandler();
            return handler.Handle(command);
        }

        public CommandResult Execute(UpdateUserCommand command)
        {
            var handler = new UserCommandHandler();
            return handler.Handle(command);
        }
                             
        public CommandResult Execute(DeleteUserCommand command)
        {
            var handler = new UserCommandHandler();
            return handler.Handle(command);
        }

        public User Execute(UserDetailsQuery command)
        {
            var handler = new UserQueryHandler();
            return handler.Handle(command);
        }

        public IEnumerable<User> Execute(UserListQuery command)
        {
            var handler = new UserQueryHandler();
            return handler.Handle(command);
        }

        #endregion
    }
}
