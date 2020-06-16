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
    //[ServiceKnownTypeAttribute(typeof(QueryResult))]
    public interface IExecutorService
    {
        #region Deposit

        [OperationContract(Name = "CreateDeposit")]
        CommandResult Execute(CreateDepositCommand command);

        #endregion

        #region Loan

        [OperationContract(Name = "CreateLoan")]
        CommandResult Execute(CreateLoanCommand command);

        #endregion

        #region User
        [OperationContract(Name = "LoginUser")]
        CommandResult Execute(LoginUserCommand command);
        [OperationContract(Name = "CreateUser")]
        CommandResult Execute(RegisterUserCommand command);
        [OperationContract(Name = "UpdateUser")]
        CommandResult Execute(UpdateUserCommand command);
        [OperationContract(Name = "DeleteUser")]
        CommandResult Execute(DeleteUserCommand command);

        [OperationContract(Name = "QueryUserDetails")]
        User Execute(UserDetailsQuery command);
        [OperationContract(Name = "QueryUsers")]
        IEnumerable<User> Execute(UserListQuery command);

        #endregion

        #region Others
        #endregion
    }
}
