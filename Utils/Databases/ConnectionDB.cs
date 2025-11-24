namespace Utils.Databases
{
    public class ConnectionDB
    {
        private static readonly string _connectionString =
            "";
        public static string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
