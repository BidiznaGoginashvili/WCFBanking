using System.ServiceModel;
using Banking.Application.Result;
using System.Collections.Generic;
using Banking.Domain.LoanManagement;
using Banking.Domain.UserManagement;
using Banking.Domain.DepositManagement;
using Banking.Application.Query.UserQueries;
using Banking.Application.Command.LoanCommands;
using Banking.Application.Command.UserCommands;
using Banking.Application.Command.DepositCommands;

namespace BankingSystemService
{
    [ServiceContract]
    [ServiceKnownTypeAttribute(typeof(CommandResult))]
    public interface IExecutorService
    {
        #region Deposit

        [OperationContract]
        CommandResult CreateDeposit(CreateDepositCommand command);

        #endregion

        #region Loan

        [OperationContract]
        CommandResult CreateLoan(CreateLoanCommand command);

        #endregion

        #region User

        [OperationContract]
        User LoginUser(LoginUserCommand command);

        [OperationContract]
        CommandResult CreateUser(RegisterUserCommand command);

        [OperationContract]
        CommandResult UpdateUser(UpdateUserCommand command);

        [OperationContract]
        CommandResult DeleteUser(DeleteUserCommand command);

        [OperationContract]
        User QueryUserDetails(UserDetailsQuery command);

        [OperationContract]
        IEnumerable<User> QueryUsers(UserListQuery command);

        #endregion

        #region Others

        [OperationContract]
        string GetRoleName(int userId);

        #endregion
    }
}
