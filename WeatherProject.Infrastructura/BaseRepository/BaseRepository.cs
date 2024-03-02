using Microsoft.EntityFrameworkCore;
using WeatherProject.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WeatherProject.Infrastructura.Persistance;
using WeatherProject.Infrastructura.Persistance;

namespace WeatherProject.Infrastructura.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        private readonly WeatherProjectsDbContext _context;
        private readonly DbSet<T> _dbSet;

       /* public BaseRepository(WeatherProjectsDbContext context)
        {
        }*/

        public BaseRepository(WeatherProjectsDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> Create(T entity)
        {
            var result = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(Expression<Func<T, bool>> expression)
        {
            var result = await _dbSet.FirstOrDefaultAsync(expression);
            if (result == null)
            {
                return false;
            }
            _dbSet.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByAny(Expression<Func<T, bool>> expression)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(expression);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<T> Update(T entity)
        {
            var result = _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
