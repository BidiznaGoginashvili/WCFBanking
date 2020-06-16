using System;
using System.Linq;
using System.Collections.Generic;
using BankingSystemService.Result;
using Banking.Domain.UserManagement;
using Banking.Infrastructure.Repository;

namespace BankingSystemService.Query.UserQueries
{
    public class UserQueryHandler :
        IRequestHandler<UserDetailsQuery, QueryResult<User>>,
        IRequestHandler<UserListQuery, QueryResult<IEnumerable<User>>>
    {
        public static Repository<User> repository = new Repository<User>();

        public QueryResult<User> Handle(UserDetailsQuery request)
        {
            try
            {
                var user = repository.GetById(request.Id);

                return new QueryResult<User>
                {
                    Entity = user
                };
            }
            catch (Exception execption)
            {
                return new QueryResult<User>
                {
                    Exception = execption
                };
            }
        }

        public QueryResult<IEnumerable<User>> Handle(UserListQuery request)
        {
            try
            {
                var users = repository.GetAll().ToList();

                if (string.IsNullOrWhiteSpace(request.FirstName))
                    users = users.Where(user => user.FirstName.Contains(request.FirstName)).ToList();
                if (string.IsNullOrWhiteSpace(request.Email))
                    users = users.Where(user => user.FirstName.Contains(request.Email)).ToList();

                return new QueryResult<IEnumerable<User>>
                {
                    Entity = users
                };
            }
            catch (Exception execption)
            {
                return new QueryResult<IEnumerable<User>>
                {
                    Exception = execption
                };
            }
        }
    }
}