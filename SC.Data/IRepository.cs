using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        //T GetById(object id);
        void Insert(T entity);
        //void Update(T entity);
        //void Delete(T entity);
        //IQueryable<T> Table { get; }
    }

    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}
