using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Dapper.Extension
{
	public class ConnectionFactory
	{
		public static void InitConnectionString()
		{
			_connectionString = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
		}

		private static string _connectionString = null;

		public static IDbConnection CreateConnection()
		{
			IDbConnection connection = new SqlConnection(_connectionString);

			return connection;
		}

		public static TransactedConnection CreateTransactedConnection()
		{
			TransactedConnection transactedConnection = new TransactedConnection(new SqlConnection(_connectionString));
			return transactedConnection;
		}

		public static TransactedConnection CreateTransactedConnection(IsolationLevel level)
		{
			TransactedConnection transactedConnection = new TransactedConnection(new SqlConnection(_connectionString), level);
			return transactedConnection;
		}
	}
}
