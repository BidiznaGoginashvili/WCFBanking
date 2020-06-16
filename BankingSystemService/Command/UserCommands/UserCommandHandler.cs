using System;
using System.Linq;
using BankingSystemService.Result;
using Banking.Domain.UserManagement;
using Banking.Domain.CityManagement;
using Banking.Domain.CountryManagement;
using Banking.Infrastructure.Repository;
using Banking.Domain.BranchManagement;

namespace BankingSystemService.Command.UserCommands
{
    public class UserCommandHandler :
        IRequestHandler<RegisterUserCommand, CommandResult<User>>,
        IRequestHandler<DeleteUserCommand, CommandResult<User>>,
        IRequestHandler<UpdateUserCommand, CommandResult<User>>,
        IRequestHandler<LoginUserCommand, CommandResult<User>>
    {
        public static Repository<User> repository = new Repository<User>();
        public static Repository<City> cityRepository = new Repository<City>();
        public static Repository<Country> countryRepository = new Repository<Country>();
        public static Repository<Branch> brancRepository = new Repository<Branch>();

        public CommandResult<User> Handle(RegisterUserCommand request)
        {
            try
            {
                var user = new User(request.FirstName, request.LastName, request.Gender, request.UniqueNumber,
                    request.BirthDay, request.Address, request.Email, request.Phone);

                var country = countryRepository.GetById(request.CountryId);
                user.Country = country;

                var city = cityRepository.GetById(request.CityId);
                user.City = city;

                user.Branches = brancRepository.GetById(request.BranchId);

                repository.Insert(user);

                return new CommandResult<User>
                {
                    Entity = user
                };
            }
            catch (Exception exception)
            {
                return new CommandResult<User>
                {
                    Success = false,
                    Exception = exception
                };
            }
        }

        public CommandResult<User> Handle(DeleteUserCommand request)
        {
            try
            {
                var user = repository.GetById(request.Id);

                if (user != null)
                    repository.Delete(user);

                return new CommandResult<User>();
            }
            catch (Exception exception)
            {
                return new CommandResult<User>
                {
                    Success = false,
                    Exception = exception
                };
            }
        }

        public CommandResult<User> Handle(UpdateUserCommand request)
        {
            try
            {
                var user = repository.GetById(request.Id);
                var updated = new User(request.FirstName, request.LastName, request.Gender, request.UniqueNumber,
                    request.BirthDay, request.Address, request.Email, request.Phone);

                var country = countryRepository.GetById(request.CountryId);
                user.Country = country;

                var city = cityRepository.GetById(request.CityId);
                user.City = city;

                repository.Update(user);

                return new CommandResult<User>
                {
                    Entity = updated
                };
            }
            catch (Exception exception)
            {
                return new CommandResult<User>
                {
                    Success = false,
                    Exception = exception
                };
            }
        }

        public CommandResult<User> Handle(LoginUserCommand request)
        {
            try
            {
                var user = new User();
                if (!string.IsNullOrWhiteSpace(request.Email) && !string.IsNullOrWhiteSpace(request.Password))
                    user = repository.GetAll().FirstOrDefault(u => u.Email == request.Email &&
                                                     u.UniqueNumber == request.Password);
                return new CommandResult<User>
                {
                    Success = true,
                    Entity = user
                };
            }
            catch (Exception exception)
            {
                return new CommandResult<User>
                {
                    Success = false,
                    Exception = exception
                };
            }
        }
    }
}