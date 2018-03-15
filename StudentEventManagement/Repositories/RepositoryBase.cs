using StudentEventManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentEventManagement.Repositories
{
    public abstract class RepositoryBase<TEntity>: IRepositoryBase<TEntity>
        where TEntity : class, IEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _entities;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _entities;
        }

        public TEntity Get(int Id)
        {
            return _entities.Find(Id);
        }

        public void Create(TEntity entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var toRemove = Get(id);
            _entities.Remove(toRemove);
            _context.SaveChanges();
        }
    }
}