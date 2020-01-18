using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EntityFactory<T>
        where T:new()
    {
        private static EntityFactory<T> instance;
        private static string connectionString;

        public EntityFactory(string connectionString)
        {
           EntityFactory<T>.connectionString = connectionString;
        }

        public static EntityFactory<T> GetInstance()
        {
            return instance ?? (instance = new EntityFactory<T>(connectionString));
        }

        public Entity<T> CreateEntity()
        {
            return new Entity<T>(connectionString);
        }
    }
}
