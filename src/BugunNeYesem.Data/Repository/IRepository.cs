using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BugunNeYesem.Data.Entity;

namespace BugunNeYesem.Data.Repository
{
    public interface IRepository
    {
        bool SaveChanges();
    }

    public interface IRepository<T> : IRepository
           where T : BaseEntity
    {
        T Insert(T entity);
        T Update(T entity);

        void Delete(long id);
        void Delete(Expression<Func<T, bool>> where);

        T SelectFirst(long id, bool isNotCached = false, params Expression<Func<T, object>>[] includeProperties);
        T SelectFirst(Expression<Func<T, bool>> where = null, bool isNotCached = false, params Expression<Func<T, object>>[] includeProperties);
        T SelectLast(Expression<Func<T, bool>> where = null, bool isNotCached = false, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> SelectAllOrdered<T2>(Expression<Func<T, bool>> where = null, Expression<Func<T, T2>> orderBy = null, bool isOrderByAsc = true, bool isNotCached = false, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> SelectPageOrdered<T2>(int pageSize, int pageNumber, Expression<Func<T, bool>> where = null, Expression<Func<T, T2>> orderBy = null, bool isOrderByAsc = true, bool isNotCached = false, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> SelectAll(Expression<Func<T, bool>> where = null, bool isNotCached = false, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> SelectPage(int pageSize, int pageNumber, Expression<Func<T, bool>> where = null, bool isNotCached = false, params Expression<Func<T, object>>[] includeProperties);

        bool Any(Expression<Func<T, bool>> where);
        long Count(Expression<Func<T, bool>> where);
        long Max(Expression<Func<T, int>> column, Expression<Func<T, bool>> where = null);
        long Min(Expression<Func<T, int>> column, Expression<Func<T, bool>> where = null);
        long Sum(Expression<Func<T, long>> column, Expression<Func<T, bool>> where = null);

        void BulkInsertSlow(IEnumerable<T> entities);
    }
}
