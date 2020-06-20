using System.Linq;
using System.Collections.Generic;
using Banking.Domain.UserManagement;
using Banking.Infrastructure.DataBase;

namespace Banking.Application.Query.UserQueries
{
    public class UserQueryHandler :
        IRequestHandler<UserDetailsQuery, User>,
        IRequestHandler<UserListQuery, IEnumerable<User>>
    {
        public BankingContext context;
        public UserQueryHandler()
        {
            context = new BankingContext();
        }

        public User Handle(UserDetailsQuery request) => context.User.SingleOrDefault(user => user.Id == request.Id);

        public IEnumerable<User> Handle(UserListQuery request)
        {
            var users = context.User.ToList();

            if (!string.IsNullOrWhiteSpace(request.FirstName))
                users = users.Where(user => user.FirstName.Contains(request.FirstName)).ToList();
            if (!string.IsNullOrWhiteSpace(request.Email))
                users = users.Where(user => user.FirstName.Contains(request.Email)).ToList();

            return users;
        }
    }
}