using DataAccess;
using DataModel;
using System.Collections.Generic;

namespace ORM
{
    /// <summary>
    /// Class describes the set of entities from the table of the database.
    /// </summary>
    /// <typeparam name="T">Universal type of entity.</typeparam>
    public class DbSet<T> : List<T>
        where T : IEntity, new()
    {
        private readonly DAO<T> dao;

        /// <summary>
        /// Constructor create an instanse of the set.
        /// </summary>
        /// <param name="connectionString">Argument represents connection string.</param>
        public DbSet(string connectionString)
        {
            dao = DAO<T>.GetInstance(connectionString);
            AddRange(dao.GetAll());
        }

        /// <summary>
        /// Method for adding new entity to the set and database.
        /// </summary>
        /// <param name="entity"></param>
        public new void Add(T entity)
        {
            base.Add(dao.Create(entity));
        }

        /// <summary>
        /// Method for adding a range of entities to the set and database.
        /// </summary>
        /// <param name="entities">List of entities.</param>
        public void AddRange(List<T> entities)
        {
            foreach (var item in entities)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Method for finding an entity with given id.
        /// </summary>
        /// <param name="id">Identity code of entity.</param>
        /// <returns>Entity with given id.</returns>
        public T Find(int id)
        {
            var result = dao.GetSingle(id);
            if (!Contains(result)) Add(result);
            return result;
        }
    }
}
