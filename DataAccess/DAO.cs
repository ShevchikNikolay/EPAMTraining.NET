using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Grammar;

namespace DataAccess
{
    public class DAO<T>
        where T : new()
    {
        private static string connectionString;
        private static DAO<T> instance;

        private DAO(string connectionString)
        {
            DAO<T>.connectionString = connectionString;
        }

        public static DAO<T> GetInstance (string connectionString)
        {
            return instance ?? (instance = new DAO<T>(connectionString));
        }

        public T Create(T obj)
        {
            int result;
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

        public void Update(T obj, List<string> propertiesToUpdate)
        {
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