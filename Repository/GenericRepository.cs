using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using mcq_backend.Helper.Context;
using Microsoft.EntityFrameworkCore;

namespace mcq_backend.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DBContext _context;
        private DbSet<T> dbSet;

        public GenericRepository(DBContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public async Task<T> GetById(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<T> GetFirst(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IList<T>> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "", int first = 0,
            int offset = 0,
            bool isIgnore = false)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (offset > 0)
            {
                query = query.Skip(offset);
            }

            if (first > 0)
            {
                query = query.Take(first);
            }

            if (isIgnore)
            {
                query = query.IgnoreQueryFilters();
            }

            query = includeProperties
                .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty)
                    => current.Include(includeProperty));
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentException("Entity cannot be null!");
            dbSet.Add(entity);
        }

        public void InsertMany(ICollection<T> entities)
        {
            if (entities.Count <= 0) throw new ArgumentException("Entity list cannot be null!");
            dbSet.AddRange(entities);
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentException("Entity cannot be null!");
            dbSet.Attach(entity);
            dbSet.Update(entity);
        }

        public void Delete(object id)
        {
            T entity = dbSet.Find(id);
            dbSet.Attach(entity);
            dbSet.Remove(entity);
        }

        public IList<T> RawSelect(FormattableString query)
        {
            var resp = dbSet.FromSqlInterpolated(query).ToList();
            return resp;
        }
    }
}