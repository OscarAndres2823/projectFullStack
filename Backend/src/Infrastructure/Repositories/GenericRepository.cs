using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepository <T> : IGenericRepository<T> where T : class
    {
        private readonly SgtaDbContext _context;
        public GenericRepository(SgtaDbContext context)
        {
            _context = context;
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id) ?? throw new KeyNotFoundException($"Entity of type {typeof(T).Name} with ID {id} not found.");
            return entity!;
        }

        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

    }
}