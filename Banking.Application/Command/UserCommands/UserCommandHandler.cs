using System;
using System.Linq;
using Banking.Application.Result;
using Banking.Domain.UserManagement;
using Banking.Domain.BranchManagement;
using Banking.Infrastructure.DataBase;
using Banking.Infrastructure.Repository;
using System.Data.Entity;

namespace Banking.Application.Command.UserCommands
{
    public class UserCommandHandler :
        IRequestHandler<RegisterUserCommand, CommandResult>,
        IRequestHandler<DeleteUserCommand, CommandResult>,
        IRequestHandler<UpdateUserCommand, CommandResult>,
        IRequestHandler<LoginUserCommand, User>
    {
        public BankingContext context;
        public UserCommandHandler()
        {
            context = new BankingContext();
        }

        public Repository<User> repository = new Repository<User>();
        public Repository<Branch> brancRepository = new Repository<Branch>();

        public CommandResult Handle(RegisterUserCommand request)
        {
            try
            {
                var checkUser = context.User.Any(us => us.Email == request.Email);
                if(checkUser)
                {
                    return new CommandResult(false, "User exists");
                }

                var user = new User(request.FirstName, request.LastName, request.Gender, request.UniqueNumber,
                    request.BirthDay, request.Address, request.Email, request.Phone);

                var branch = context.Branches.SingleOrDefault(br => br.Id == request.BranchId);
                user.Branches = branch;

                //ToRefactor
                user.Role = context.Role.SingleOrDefault(role => role.Name == "Registered");

                branch.Users.Add(user);
                context.SaveChanges();

                return new CommandResult(true, "", user.Id);
            }
            catch (Exception exception)
            {
                return new CommandResult(false, exception.Message);
            }
        }

        public CommandResult Handle(DeleteUserCommand request)
        {
            try
            {
                var user = repository.GetById(request.Id);

                if (user != null)
                    repository.Delete(user);

                return new CommandResult(true);
            }
            catch (Exception exception)
            {
                return new CommandResult(false, exception.Message);
            }
        }

        public CommandResult Handle(UpdateUserCommand request)
        {
            try
            {
                var user = context.User.SingleOrDefault(us => us.Id == request.Id);
                var updated = new User(request.FirstName, request.LastName, request.Gender, request.UniqueNumber,
                    request.BirthDay, request.Address, request.Email, request.Phone);

                repository.Update(user);

                return new CommandResult(true, "", user.Id);
            }
            catch (Exception exception)
            {
                return new CommandResult(false, exception.Message);
            }
        }

        public User Handle(LoginUserCommand request)
        {

            var user = new User();
            if (!string.IsNullOrWhiteSpace(request.Email) && !string.IsNullOrWhiteSpace(request.Password))
                user = repository.GetAll().FirstOrDefault(u => u.Email == request.Email &&
                                                 u.UniqueNumber == request.Password);
            
            return user;
        }
    }
}