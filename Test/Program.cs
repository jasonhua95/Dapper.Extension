using Dapper;
using Dapper.Extension;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("项目启动开始");
			ConnectionFactory.InitConnectionString();
			Test();
			//TestDapper();
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

		/// <summary>
		/// Dapper的测试
		/// </summary>
		private static void TestDapper() {
			var _connectionString = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
			IDbConnection conn = new SqlConnection(_connectionString);
			conn.Open();

			long idLong = DateTime.Now.Ticks;
			var dog = new Dog { Id = idLong, Name = "小红", Age = 2, Weight = 10 };

			string query = "INSERT INTO Dogs(Id,Name,Age,Weight) VALUES(@Id,@Name,@Age,@Weight)";
			conn.Execute(query, dog);

			dog.Name = "红红";
			query = "UPDATE Dogs SET  Name=@name WHERE id =@id";
			conn.Execute(query, dog);
			//conn.Execute(query, new { @name = dog });//参数这样写也是可以的

			query = "DELETE FROM Dogs WHERE id = @id";
			conn.Execute(query, new { id = dog.Id });

			var name = "红";

			query = "SELECT * FROM Dogs";
			var list = conn.Query<Dog>(query).ToList();

			query = "INSERT INTO Dogs(Id,Name,Age,Weight) VALUES(@Id,@Name,@Age,@Weight)";
			conn.Execute(query, new List<Dog>(){
				new Dog{ Id = DateTime.Now.Ticks+1, Name = "小红1", Age = 2, Weight = 10 },
				new Dog { Id = DateTime.Now.Ticks+2, Name = "小红2", Age = 2, Weight = 10 },
				new Dog { Id = DateTime.Now.Ticks+3, Name = "小红3", Age = 2, Weight = 10 },
				new Dog { Id = DateTime.Now.Ticks+4, Name = "小红3", Age = 2, Weight = 10 },
			});

			list = conn.Query<Dog>("SELECT * FROM Dogs WHERE id IN @ids ", new { ids = new long[] { list[0].Id, list[1].Id, list[2].Id } }).ToList();
			list = conn.Query<Dog>("SELECT * FROM Dogs WHERE name LIKE @name ", new { name = $"%{name}%" }).ToList();
		}

	}

}
