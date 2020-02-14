using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Grammar;

namespace DataAccess
{
    /// <summary>
    /// Generic class provides access to database.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DAO<T>
        where T : new()
    {
        private static string connectionString;
        private static DAO<T> instance;

        private DAO(string connectionString)
        {
            DAO<T>.connectionString = connectionString;
        }

        /// <summary>
        /// Singletone pattern realization.
        /// </summary>
        /// <param name="connectionString">String argument, that represents connection string.</param>
        /// <returns>Instance of data access object.</returns>
        public static DAO<T> GetInstance(string connectionString)
        {
            return instance ?? (instance = new DAO<T>(connectionString));
        }

        /// <summary>
        /// Method of insertion any entity into database.
        /// </summary>
        /// <param name="obj">Argument represents entity to insertion.</param>
        /// <returns>Inserted entity with identity code.</returns>
        public T Create(T obj)
        {
            var type = obj.GetType();
            var tableName = Plural.Convert(type.Name);
            var properties = type.GetProperties();
            var columnNames = new StringBuilder();
            var parameterNames = new StringBuilder();
            var command = new SqlCommand();
            var pid = new SqlParameter
            {
                ParameterName = "INSERTED_ID",
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(pid);

            foreach (var item in properties)
            {
                if (item.Name == "Id") continue;
                columnNames.Append($"{item.Name},");
                parameterNames.Append($"@{item.Name},");
                command.Parameters.Add(new SqlParameter($"@{item.Name}", item));
            }

            columnNames.Remove(columnNames.Length - 1, 1);
            parameterNames.Remove(parameterNames.Length - 1, 1);

            command.CommandText = $"INSERT INTO {tableName} ({columnNames}) VALUES ({parameterNames})";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();

                obj.GetType().GetProperty("Id").SetValue(this, Int32.Parse(pid.Value.ToString()));
            }
            return obj;
        }

        /// <summary>
        /// Methode for updating entities in database.
        /// </summary>
        /// <param name="obj">Entity to update.</param>
        /// <param name="propertiesToUpdate">Argument represents a list of properties to particular 
        /// updating entity.</param>
        public void Update(T obj, List<string> propertiesToUpdate)
        {
            if (propertiesToUpdate.Count == 0)
            {
                foreach (var item in obj.GetType().GetProperties())
                {
                    propertiesToUpdate.Add(item.Name);
                }

            }
            var type = obj.GetType();
            var tableName = Plural.Convert(type.Name);
            var id = type.GetProperty("Id");
            var setString = new StringBuilder();
            var command = new SqlCommand();
            command.Parameters.AddWithValue("@Id", id);

            foreach (var item in propertiesToUpdate)
            {
                setString.Append($"{item}=@{item},");
                command.Parameters.Add(new SqlParameter($"@{item}", type.GetProperty(item)));
            }
            setString.Remove(setString.Length - 1, 1);

            command.CommandText = $"UPDATE {tableName} SET {setString} WHERE Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Methode for deleting an entity from the database.
        /// </summary>
        /// <param name="id">Identity code of the entity to delete.</param>
        public void Delete(int id)
        {
            var type = typeof(T);
            var tableName = Plural.Convert(type.Name);
            var command = new SqlCommand();
            command.Parameters.Add(new SqlParameter("@Id", id));
            command.CommandText = $"DELETE FROM {tableName} WHERE Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Methode for getting single entity from the database.
        /// </summary>
        /// <param name="id">Identity code.</param>
        /// <returns>Entity with given id.</returns>
        public T GetSingle(int id)
        {
            var type = typeof(T);
            var tableName = Plural.Convert(type.Name);
            var command = new SqlCommand();
            command.Parameters.Add(new SqlParameter("@Id", id));
            command.CommandText = $"SELECT * FROM {tableName} WHERE Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                command.Connection = connection;
                connection.Open();
                var reader = command.ExecuteReader(CommandBehavior.SingleRow);
                reader.Read();
                if (reader.HasRows)
                {
                    var args = new object[reader.FieldCount];
                    reader.GetValues(args);
                    return (T)Activator.CreateInstance(typeof(T), args);
                }
                else
                {
                    throw new ArgumentException($"Id = {id} is not found");
                }
            }
        }

        /// <summary>
        /// Method for getting all entities from the table.
        /// </summary>
        /// <returns>List of entities.</returns>
        public List<T> GetAll()
        {
            var type = typeof(T);
            var tableName = Plural.Convert(type.Name);
            var command = new SqlCommand();
            command.CommandText = $"SELECT * FROM {tableName}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var listResult = new List<T>();
                command.Connection = connection;
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var args = new object[reader.FieldCount];
                    reader.GetValues(args);
                    listResult.Add((T)Activator.CreateInstance(typeof(T), args));
                }
                return listResult;
            }
        }
    }
}