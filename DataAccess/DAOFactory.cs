namespace DataAccess
{
    public class DAOFactory<T>
        where T : new()
    {
        private static DAOFactory<T> instance;
        private static string connectionString;

        public DAOFactory(string connectionString)
        {
            DAOFactory<T>.connectionString = connectionString;
        }

        public static DAOFactory<T> GetInstance()
        {
            return instance ?? (instance = new DAOFactory<T>(connectionString));
        }

        public DAO<T> CreateEntity()
        {
            return new DAO<T>(connectionString);
        }
    }
}
