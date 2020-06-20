using System.Collections.Generic;
using Banking.Application.Result;
using Banking.Domain.UserManagement;
using Banking.Application.Query.UserQueries;
using Banking.Application.Command.LoanCommands;
using Banking.Application.Command.UserCommands;
using Banking.Application.Command.DepositCommands;
using Banking.Infrastructure.DataBase;
using System.Linq;

namespace BankingSystemService
{
    public class ExecutorService : IExecutorService
    {
        #region Deposit

        public CommandResult CreateDeposit(CreateDepositCommand command)
        {
            var handler = new DepositCommandHandler();
            return handler.Handle(command);
        }

        #endregion

        #region Loan

        public CommandResult CreateLoan(CreateLoanCommand command)
        {
            var handler = new LoanCommandHandler();
            return handler.Handle(command);
        }

        #endregion

        #region User

        public CommandResult CreateUser(RegisterUserCommand command)
        {
            var handler = new UserCommandHandler();
            return handler.Handle(command);
        }

        public User LoginUser(LoginUserCommand command)
        {
            var handler = new UserCommandHandler();
            return handler.Handle(command);
        }

        public CommandResult UpdateUser(UpdateUserCommand command)
        {
            var handler = new UserCommandHandler();
            return handler.Handle(command);
        }
                             
        public CommandResult DeleteUser(DeleteUserCommand command)
        {
            var handler = new UserCommandHandler();
            return handler.Handle(command);
        }

        public User QueryUserDetails(UserDetailsQuery command)
        {
            var handler = new UserQueryHandler();
            return handler.Handle(command);
        }

        public IEnumerable<User> QueryUsers(UserListQuery command)
        {
            var handler = new UserQueryHandler();
            return handler.Handle(command);
        }

        //ToRemove added because of wcf ef loading error
        public string GetRoleName(int userId)
        {
            using (var context = new BankingContext())
            {
                var user = context.User.Include("Role").SingleOrDefault(us => us.Id == userId);
                return user.Role.Name;
            };
        }

        #endregion
    }
}
