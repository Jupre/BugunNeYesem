using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BugunNeYesem.Data.Entity;

namespace BugunNeYesem.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public virtual T Insert(T entity)
        {

            _context.Set<T>().Add(entity);
            return entity;
        }

        public virtual T Update(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Delete(long id)
        {
            var entity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entity);
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            var objects = _context.Set<T>().Where(where).AsEnumerable();
            foreach (var item in objects)
            {
                _context.Set<T>().Remove(item);
                _context.Entry(item).State = EntityState.Deleted;
            }
        }

        public T SelectFirst(long id,
                             bool isNotCached = false,
                             params Expression<Func<T, object>>[] includeProperties)
        {
            var entity = SelectAll(x => x.Id == id, isNotCached, includeProperties);
            return entity.FirstOrDefault();
        }

        public virtual T SelectFirst(Expression<Func<T, bool>> where = null,
                                      bool isNotCached = false,
                                      params Expression<Func<T, object>>[] includeProperties)
        {
            var entity = SelectAll(where, isNotCached, includeProperties);
            return entity.FirstOrDefault();
        }

        public virtual T SelectLast(Expression<Func<T, bool>> where = null,
                                    bool isNotCached = false,
                                    params Expression<Func<T, object>>[] includeProperties)
        {
            var entity = SelectAllOrdered(where, x => x.CreatedDate, false, isNotCached, includeProperties);
            return entity.FirstOrDefault();
        }

        public virtual IQueryable<T> SelectAllOrdered<T2>(Expression<Func<T, bool>> where = null,
                                                          Expression<Func<T, T2>> orderBy = null,
                                                          bool isOrderByAsc = true,
                                                          bool isNotCached = false,
                                                          params Expression<Func<T, object>>[] includeProperties)
        {
            var items = where != null ? _context.Set<T>().Where(where)
                                      : _context.Set<T>();

            if (orderBy != null
                && isOrderByAsc)
            {
                items = items.OrderBy(orderBy);
            }
            else if (orderBy != null)
            {
                items = items.OrderByDescending(orderBy);
            }

            foreach (var property in includeProperties)
            {
                items.Include(property);
            }

            if (isNotCached)
            {
                items = items.AsNoTracking();
            }

            return items;
        }

        public IQueryable<T> SelectPageOrdered<T2>(int pageSize, int pageNumber,
                                                   Expression<Func<T, bool>> where = null,
                                                   Expression<Func<T, T2>> orderBy = null,
                                                   bool isOrderByAsc = true,
                                                   bool isNotCached = false,
                                                   params Expression<Func<T, object>>[] includeProperties)
        {
            if (pageSize < 1)
            {
                pageSize = 1000;
            }

            pageSize = Math.Min(1000, pageSize);
            pageNumber = Math.Max(0, pageNumber);

            var items = where != null ? _context.Set<T>().Where(where) : _context.Set<T>();

            if (orderBy != null
               && isOrderByAsc)
            {
                items = items.OrderBy(orderBy);
            }
            else if (orderBy != null)
            {
                items = items.OrderByDescending(orderBy);
            }
            else
            {
                items = items.OrderByDescending(x => x.CreatedDate);
            }

            items = items.Skip(pageSize * pageNumber).Take(pageSize);
            foreach (var property in includeProperties)
            {
                items.Include(property);
            }

            if (isNotCached)
            {
                items = items.AsNoTracking();
            }

            return items;
        }

        public virtual IQueryable<T> SelectAll(Expression<Func<T, bool>> where = null,
                                                   bool isNotCached = false,
                                                   params Expression<Func<T, object>>[] includeProperties)
        {
            var items = where != null ? _context.Set<T>().Where(where)
                                      : _context.Set<T>();

            foreach (var property in includeProperties)
            {
                items.Include(property);
            }

            if (isNotCached)
            {
                items = items.AsNoTracking();
            }

            return items;
        }

        public IQueryable<T> SelectPage(int pageSize, int pageNumber,
                                        Expression<Func<T, bool>> where = null,
                                        bool isNotCached = false,
                                        params Expression<Func<T, object>>[] includeProperties)
        {
            if (pageSize < 1)
            {
                pageSize = 1000;
            }

            pageSize = Math.Min(1000, pageSize);
            pageNumber = Math.Max(0, pageNumber);

            var items = where != null ? _context.Set<T>().Where(where) : _context.Set<T>();

            items = items.OrderByDescending(x => x.CreatedDate).Skip(pageSize * pageNumber).Take(pageSize);
            foreach (var property in includeProperties)
            {
                items.Include(property);
            }

            if (isNotCached)
            {
                items = items.AsNoTracking();
            }

            return items;
        }

        public virtual bool Any(Expression<Func<T, bool>> where)
        {
            return _context.Set<T>().Any(where);
        }

        public virtual long Count(Expression<Func<T, bool>> where)
        {
            return _context.Set<T>().Count(where);
        }

        public virtual long Max(Expression<Func<T, int>> column, Expression<Func<T, bool>> where = null)
        {
            return where != null ? _context.Set<T>().Where(where).Select(column).DefaultIfEmpty(0).Max()
                                 : _context.Set<T>().Select(column).DefaultIfEmpty(0).Max();
        }

        public virtual long Min(Expression<Func<T, int>> column, Expression<Func<T, bool>> where = null)
        {
            return where != null ? _context.Set<T>().Where(where).Min(column)
                                 : _context.Set<T>().Min(column);
        }

        public virtual long Sum(Expression<Func<T, long>> column, Expression<Func<T, bool>> where = null)
        {
            return where != null ? _context.Set<T>().Where(where).Select(column).DefaultIfEmpty(0).Sum()
                                : _context.Set<T>().Select(column).DefaultIfEmpty(0).Sum();
        }

        public void BulkInsertSlow(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Set<T>().Add(entity);
                _context.Entry(entity).State = EntityState.Added;
            }
        }

        public virtual bool SaveChanges()
        {
            return 0 < _context.SaveChanges();
        }
    }
}
