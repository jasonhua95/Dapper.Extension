using System.Data;
using System.Data.SqlClient;

namespace Store.Core.Data
{
	public enum DatabaseType
	{
		SqlServer = 1
	}
	public class ConnectionFactory
	{
		/// <summary>
		/// 数据库连接信息
		/// </summary>
		internal static string ConnectionString = null;
		internal static DatabaseType Dbtype { get; set; }

		public static SqlConnectInfo ConnectInfo
		{
			set
			{
				ConnectionString = value.ConnectionString;
				switch(value.ProviderName)
				{
					case "System.Data.SqlClient":
						Dbtype = DatabaseType.SqlServer;
						break;
				}
			}
		}

		public static IDbConnection CreateConnection()
		{
			IDbConnection connection = null;

			switch (Dbtype)
			{
				case DatabaseType.SqlServer:
					connection = new SqlConnection(ConnectionString);
					break;
			}
			if (connection.State == ConnectionState.Closed)
			{
				connection.Open();
			}
			return connection;
		}

		public static IDbSession CreateDbSession()
		{
			IDbSession dbsession = null;
			switch (Dbtype)
			{
				case DatabaseType.SqlServer:
					dbsession = new DbSession(ConnectionString);
					break;
			}
			return dbsession;
		}

		public static IDbSession CreateDbSession(IsolationLevel level)
		{
			IDbSession dbsession = null;
			switch (Dbtype)
			{
				case DatabaseType.SqlServer:
					dbsession = new DbSession(ConnectionString, level);
					break;
			}
			return dbsession;
		}
	}
}
