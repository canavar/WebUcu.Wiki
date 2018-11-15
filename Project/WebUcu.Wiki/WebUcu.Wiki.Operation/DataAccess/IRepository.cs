using System;
using System.Collections.Generic;
using System.Text;

namespace WebUcu.Wiki.Operation.DataAccess
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);
        void Edit(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> SelectAll();
    }
}
