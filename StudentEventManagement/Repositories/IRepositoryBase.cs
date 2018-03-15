using StudentEventManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentEventManagement.Repositories
{
    public interface IRepositoryBase<TEntity>
        where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();
        TEntity Get(int Id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}