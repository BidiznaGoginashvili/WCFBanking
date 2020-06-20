using System;
using System.Linq;
using System.Collections.Generic;
using Banking.Infrastructure.DataBase;
using System.Data.Entity.Validation;

namespace Banking.Infrastructure.Repository
{
    public class Repository<T> where T : class
    {
        #region Fields

        private readonly BankingContext _context;

        #endregion

        #region Ctor

        public Repository()
        {
            _context = new BankingContext();
        }

        #endregion

        #region Methods

        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                _context.Set<T>().Add(entity);
                _context.SaveChangesAsync();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetValidations(dbEx));
            }
        }

        public virtual void Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    _context.Set<T>().Add(entity);

                _context.SaveChangesAsync();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetValidations(dbEx));
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetValidations(dbEx));
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                _context.Set<T>().Remove(entity);

                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetValidations(dbEx));
            }
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    _context.Set<T>().Remove(entity);

                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetValidations(dbEx));
            }
        }

        public virtual T GetById(object id)
        {
            return _context.Set<T>().Find();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public string GetValidations(DbEntityValidationException exception)
        {
            var entityValidationErrors = exception.EntityValidationErrors
                      .SelectMany(validation => validation.ValidationErrors
                          .Select(error => error.ErrorMessage));

            return string.Join(";", entityValidationErrors.ToArray());
        }

        #endregion
    }
}
