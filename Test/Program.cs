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
			InsertTest();
			//try {
			//	int i = 0;
			//	while (i < 1000)
			//	{
			//		//TestBase test = new TestBase();
			//		//using (SqlConnection sql = new SqlConnection(TestBase.ConnectionString)) {
			//		//	//var users = sql.Query("SELECT TOP 1000 [id],[name] ,[age] FROM [Test].[dbo].[t_user]");
			//		//	//sql.Open();
			//		//	//using (var transaction = sql.BeginTransaction())
			//		//	//{
			//		//	//	sql.Execute("insert into [t_user] ([id], [name],[age]) values (1, 'ABC',12);", transaction: transaction);
			//		//	//	transaction.Commit();
			//		//	//}

			//		//	TransactedConnection conn = new TransactedConnection(sql);
			//		//	conn.Execute("insert into [t_user] ([id], [name],[age]) values (1, 'ABC',12);");
			//		//	conn.Execute("insert into [t_user] ([id], [name],[age]) values (1, 'ABC',12);");
			//		//	conn.Execute("insert into [t_user] ([id], [name],[age]) values (1, 'ABC',12);");
			//		//	//conn.Commit();
			//		//}

			//		//using (IDbConnection conn = ConnectionFactory.CreateConnection())
			//		//{
			//		//	var users = conn.Query("SELECT TOP 1000 [id],[name] ,[age] FROM [Test].[dbo].[t_user]");
			//		//}

			//		using (var conn = ConnectionFactory.CreateTransactedConnection())
			//		{
			//			conn.Execute("insert into [t_user] ([id], [name],[age]) values (1, 'ABC',12);");
			//			conn.Execute("insert into [t_user] ([id], [name],[age]) values (1, 'ABC',12);");
			//			conn.Execute("insert into [t_user] ([id], [name],[age]) values (1, 'ABC',12);");
			//			conn.Commit();
			//		}

			//		i++;
			//	}
			//} catch (Exception ex) {
			//	Console.WriteLine("项目异常");
			//}
			Console.WriteLine("项目启动结束");
			Console.Read();
		}

		private static void InsertTest() {
			try {
				IDBManager db = new DBManager();
				var d = new Dog { Id = Guid.NewGuid().ToString(), Name = "测试1",Age=2,Weight=10 };

				var dog = db.Insert<Dog>(d);
				//db.Execute("insert into Dogs(Id,Name) values(@Id,@Name)", new Dog { Id = Guid.NewGuid().ToString(), Name = "测试1" });

			} catch (Exception ex) {
				var test = ex.ToString();
			}

			
		}
	}

}
