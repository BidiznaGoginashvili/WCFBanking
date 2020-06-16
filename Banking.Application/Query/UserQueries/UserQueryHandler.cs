using System;
using System.Linq;
using System.Collections.Generic;
using Banking.Domain.UserManagement;
using Banking.Infrastructure.Repository;

namespace Banking.Application.Query.UserQueries
{
    public class UserQueryHandler :
        IRequestHandler<UserDetailsQuery, User>,
        IRequestHandler<UserListQuery, IEnumerable<User>>
    {
        public static Repository<User> repository = new Repository<User>();

        public User Handle(UserDetailsQuery request)
        {
            try
            {
                var user = repository.GetById(request.Id);

                return user;
            }
            catch (Exception execption)
            {
                return default(User);
            }
        }

        public IEnumerable<User> Handle(UserListQuery request)
        {
            try
            {
                var users = repository.GetAll().ToList();

                if (string.IsNullOrWhiteSpace(request.FirstName))
                    users = users.Where(user => user.FirstName.Contains(request.FirstName)).ToList();
                if (string.IsNullOrWhiteSpace(request.Email))
                    users = users.Where(user => user.FirstName.Contains(request.Email)).ToList();

                return users;
            }
            catch (Exception execption)
            {
                return default(IEnumerable<User>);
            }
        }
    }
}