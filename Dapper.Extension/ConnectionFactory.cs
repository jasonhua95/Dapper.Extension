using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Dapper.Extension
{
	/// <summary>
	/// 数据库的链接类(sql server),将来数据库切换只用修改这里(SqlConnection),修改它就可以了
	/// </summary>
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
