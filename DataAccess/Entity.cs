using System;
using System.Collections.Generic;
using System.Reflection;

namespace DataAccess
{
    public class Entity<T>
        where T:new()
    {
        private string connectionString;

        public Entity(string connectionString)
        {
            this.connectionString = connectionString;
        }



        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetSingle(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}