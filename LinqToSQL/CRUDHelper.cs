using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSQL
{
    public class CRUDHelper<T> where T: class ,IEntity
    {
        public static void Create(T entity)
        {
            using (var db = new MapingDataContext())
            {
                var table = db.GetTable<T>();
                table.InsertOnSubmit(entity);
                db.SubmitChanges();
            }
        }

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
