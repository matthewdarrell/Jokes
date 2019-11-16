using Jokes.Core.Entities;
using Jokes.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Jokes.Infrastructure.Data
{
    public class EFCoreRepository : IRepository
    {
        private readonly AppDbContext _dbContext;

        public EFCoreRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public int Count<T>() where T : BaseEntity =>
            _dbContext.Set<T>().Count();

        public void Create<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }
            
        public void Delete<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteById<T>(int id) where T : BaseEntity
        {
            var entity = GetById<T>(id);
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public T GetById<T>(int id) where T : BaseEntity => 
            _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);

        public List<T> List<T>() where T : BaseEntity => 
            _dbContext.Set<T>().ToList();

        public List<T> List<T>(int start, int step) where T : BaseEntity =>
            _dbContext.Set<T>().Skip(start).Take(step).ToList();


        // Throwing an error: id already tracked
        //public void Update<T>(T entity) where T : BaseEntity
        //{
        //    _dbContext.Update(entity);
        //    _dbContext.SaveChanges();
        //}
    }
}
