using Dapper;
using Dapper.Contrib.Extensions;
using Dapper.Extension;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;

namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("项目启动开始");
			ConnectionFactory.InitConnectionString();
			try {
				int i = 0;
				while (i < 1000)
				{
					//TestBase test = new TestBase();
					//using (SqlConnection sql = new SqlConnection(TestBase.ConnectionString)) {
					//	//var users = sql.Query("SELECT TOP 1000 [id],[name] ,[age] FROM [Test].[dbo].[t_user]");
					//	//sql.Open();
					//	//using (var transaction = sql.BeginTransaction())
					//	//{
					//	//	sql.Execute("insert into [t_user] ([id], [name],[age]) values (1, 'ABC',12);", transaction: transaction);
					//	//	transaction.Commit();
					//	//}

					//	TransactedConnection conn = new TransactedConnection(sql);
					//	conn.Execute("insert into [t_user] ([id], [name],[age]) values (1, 'ABC',12);");
					//	conn.Execute("insert into [t_user] ([id], [name],[age]) values (1, 'ABC',12);");
					//	conn.Execute("insert into [t_user] ([id], [name],[age]) values (1, 'ABC',12);");
					//	//conn.Commit();
					//}

					//using (IDbConnection conn = ConnectionFactory.CreateConnection())
					//{
					//	var users = conn.Query("SELECT TOP 1000 [id],[name] ,[age] FROM [Test].[dbo].[t_user]");
					//}

					using (var conn = ConnectionFactory.CreateTransactedConnection())
					{
						conn.Execute("insert into [t_user] ([id], [name],[age]) values (1, 'ABC',12);");
						conn.Execute("insert into [t_user] ([id], [name],[age]) values (1, 'ABC',12);");
						conn.Execute("insert into [t_user] ([id], [name],[age]) values (1, 'ABC',12);");
						conn.Commit();
					}

					i++;
				}
			} catch (Exception ex) {
				Console.WriteLine("项目异常");
			}
			Console.WriteLine("项目启动结束");
			Console.Read();
		}
	}

	public class TestBase : IDisposable
	{
		public static string ConnectionString => ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;

		protected SqlConnection _connection;
		public SqlConnection Connection => _connection ?? (_connection = GetOpenConnection());

		public static SqlConnection GetOpenConnection(bool mars = false)
		{
			var cs = ConnectionString;
			if (mars)
			{
				var scsb = new SqlConnectionStringBuilder(cs)
				{
					MultipleActiveResultSets = true
				};
				cs = scsb.ConnectionString;
			}
			var connection = new SqlConnection(cs);
			connection.Open();
			return connection;
		}

		public SqlConnection GetClosedConnection()
		{
			var conn = new SqlConnection(ConnectionString);
			if (conn.State != ConnectionState.Closed) throw new InvalidOperationException("should be closed!");
			return conn;
		}

		protected static CultureInfo ActiveCulture
		{
#if NETCOREAPP1_0
            get { return CultureInfo.CurrentCulture; }
            set { CultureInfo.CurrentCulture = value; }
#else
			get { return Thread.CurrentThread.CurrentCulture; }
			set { Thread.CurrentThread.CurrentCulture = value; }
#endif
		}

		public void Dispose()
		{
			_connection?.Dispose();
		}
	}
}
