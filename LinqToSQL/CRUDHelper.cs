using System.Linq;

namespace LinqToSQL
{
    /// <summary>
    /// Static class. Provides some methods to reduce code on CRUD operations. 
    /// </summary>
    /// <typeparam name="T">Universal type.</typeparam>
    public static class CRUDHelper<T> where T : class, IEntity
    {
        /// <summary>
        /// Method to create an entity of T type in database.
        /// </summary>
        /// <param name="entity">Argument represents an entity of universal type.</param>
        public static void Create(T entity)
        {
            using (var db = new MapingDataContext())
            {
                var table = db.GetTable<T>();
                table.InsertOnSubmit(entity);
                db.SubmitChanges();
            }
        }

        /// <summary>
        /// Method to find an entity by its identity code.
        /// </summary>
        /// <param name="id">Argument of integer type, that represent identity code.</param>
        /// <returns></returns>
        public static T Find(int id)
        {
            using (var db = new MapingDataContext())
            {
                var query = from item in db.GetTable<T>()
                            where item.id == id
                            select item;
                T entity = query.First();
                return entity;
            }
        }

        /// <summary>
        /// Method to delete an entity from database.
        /// </summary>
        /// <param name="entity">Entity to deleting.</param>
        public static void Delete(T entity)
        {
            using (var db = new MapingDataContext())
            {
                db.GetTable<T>().DeleteOnSubmit(entity);
                db.SubmitChanges();
            }
        }
    }
}
