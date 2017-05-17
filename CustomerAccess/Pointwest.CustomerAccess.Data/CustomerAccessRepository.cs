using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pointwest.CustomerAccess.Data
{
    public class CustomerAccessRepository<TEntity> where TEntity : class
    {
        protected CustomerAccess _context = new CustomerAccess();

        /// <summary>
        /// Insert one entity(Add)
        /// </summary>
        public virtual void Insert(TEntity entity)
        {
            DbSet<TEntity> dbSet = _context.Set<TEntity>();
            dbSet.Add(entity);
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                Exception raise = ex;
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        /// <summary>
        /// Delete one entity
        /// </summary>
        public virtual void Delete(TEntity entity)
        {
            DbSet<TEntity> dbSet = _context.Set<TEntity>();
            dbSet.Attach(entity);
            dbSet.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update existing entity
        /// </summary>
        public virtual void Update(TEntity entity)
        {
            DbSet<TEntity> dbSet = _context.Set<TEntity>();
            dbSet.Attach(entity);

            _context.Entry(entity).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        /// <summary>
        /// Retrieve single entity based on primary key
        /// </summary>
        public virtual TEntity RetrieveById(object key)
        {
            DbSet<TEntity> dbSet = _context.Set<TEntity>();
            return dbSet.Find(key);
        }

        /// <summary>
        /// Retrieve list of entites based on the query
        /// </summary>
        public virtual List<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            DbSet<TEntity> dbSet = _context.Set<TEntity>();
            return dbSet.Where(predicate).ToList();
        }

        /// <summary>
        /// Retrieve all entities
        /// </summary>
        /// <returns></returns>
        public virtual List<TEntity> RetrieveAll()
        {
            DbSet<TEntity> dbSet = _context.Set<TEntity>();
            return dbSet.ToList();
        }
    }
}
