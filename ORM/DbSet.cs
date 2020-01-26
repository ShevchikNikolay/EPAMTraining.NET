using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace ORM
{
    public class DbSet<T> where T : new()
    {
        private List<T> local;
        private DAO<T> dao;

        public DbSet(string connectionString)
        {
            local = new List<T>();
            dao = DAO<T>.GetInstance(connectionString);
        }

        public void Add(T entity)
        {
            local.Add(dao.Create(entity));
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
            if (!local.Contains(result)) local.Add(result);
            return result;
        }



    }
}
