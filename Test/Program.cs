using Dapper;
using Dapper.Extension;
using System;

namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("项目启动开始");
			ConnectionFactory.InitConnectionString();
			Test();
			Console.WriteLine("项目启动结束");
			Console.Read();
		}

		private static void Test() {
			IDBManager db = new DBManager();
			long idLong = DateTime.Now.Ticks;
			var dog = new Dog { Id = idLong, Name = "小红", Age = 2, Weight = 10 };
			var id = db.Insert(dog);

			var getDog = db.GetById<Dog>(dog.Id);

			dog.Name = "红红";
			db.Update(dog);

			var dogList = db.GetAll<Dog>();

			var query = db.Query<Dog>("select Id,Name,Age,Weight from Dogs;");

			var execu = db.Execute("update Dogs set Age=3 where Age is null");

			//复杂的操作，.智能提示，会有很多的方法
			using (var conn = ConnectionFactory.CreateConnection())
			{
				conn.Query("select 1");
			}
			//事务，智能提示，会有很多的方法
			using (var conn = ConnectionFactory.CreateTransactedConnection())
			{
				try {
					conn.Query("select 1");
					conn.Commit();
				} catch (Exception ex) {
					conn.Rollback();
				}
			}

			//其他复杂的操作请参照一下网站
			//https://github.com/StackExchange/Dapper
		}

	}

}
