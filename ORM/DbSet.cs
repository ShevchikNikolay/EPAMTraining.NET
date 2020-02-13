using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataModel;

namespace ORM
{
    public class DbSet<T> : List<T> 
        where T : IEntity, new () 
    {
        private readonly DAO<T> dao;

        public DbSet(string connectionString)
        {
            dao = DAO<T>.GetInstance(connectionString);
            AddRange(dao.GetAll());
        }

        public new void Add(T entity)
        {
            base.Add(dao.Create(entity));
        }

        public void AddRange(List<T> entities)
        {
            foreach (var item in entities)
            {
                Add(item);
            }
        }

        public T Find(int id)
        {
            var result = dao.GetSingle(id);
            if (!Contains(result)) Add(result);
            return result;
        }



    }
}
