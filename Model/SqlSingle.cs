using System.Data.SqlClient;

namespace ConsoleApp1
{
    class SqlSingle
    {
        protected static SqlConnection _instance { private set; get; }
        private SqlSingle() { }

        public static SqlConnection GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;");
                _instance.Open();
            }
            lock (_instance)
            {
                return _instance;
            }
        }

    }
}
