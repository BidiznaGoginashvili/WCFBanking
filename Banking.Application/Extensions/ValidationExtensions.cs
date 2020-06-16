using System;
using System.Linq;
using System.Data.Entity.Validation;

namespace Banking.Application.Extensions
{
    public static class ValidationExtensions
    {
        public static string GetValidations(this DbEntityValidationException exception)
        {
            var entityValidationErrors = exception.EntityValidationErrors
                      .SelectMany(validation => validation.ValidationErrors
                          .Select(error => error.ErrorMessage));

            return string.Join(";", entityValidationErrors.ToArray());
        }
    }
}
