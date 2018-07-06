using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Dapper.Extension
{
	public class DBManager : IDBManager
	{
		public long Insert<T>(T t) where T : class
		{
			using (var conn = ConnectionFactory.CreateConnection())
			{
				return conn.Insert(t);
			}
		}

		public long Insert<T>(IEnumerable<T> list) where T : class
		{
			using (var conn = ConnectionFactory.CreateConnection())
			{
				return conn.Insert(list);
			}
		}

		public bool Update<T>(T t) where T : class
		{
			using (var conn = ConnectionFactory.CreateConnection())
			{
				return conn.Update(t);
			}
		}

		public bool Update<T>(IEnumerable<T> list) where T : class
		{
			using (var conn = ConnectionFactory.CreateConnection())
			{
				return conn.Update(list);
			}
		}

		public bool Delete<T>(dynamic id) where T : class
		{
			using (var conn = ConnectionFactory.CreateConnection())
			{
				conn.Open();
				T t = conn.Get<T>(id as object);
				return conn.Delete(t);
			}
		}

		public bool Delete<T>(IEnumerable<dynamic> idList) where T : class
		{
			using (var conn = ConnectionFactory.CreateConnection())
			{
				conn.Open();
				List<T> tList = new List<T>();
				foreach (var id in idList) {
					T t = conn.Get<T>(id as object);
					tList.Add(t);
				}

				return conn.Delete(tList);
			}
		}

		public T GetById<T>(dynamic id) where T : class
		{
			using (var conn = ConnectionFactory.CreateConnection())
			{
				return conn.Get<T>(id as object);
			}
		}

		public IEnumerable<T> GetAll<T>() where T : class
		{
			using (var conn = ConnectionFactory.CreateConnection())
			{
				return conn.GetAll<T>();
			}
		}

		public IEnumerable<T> Query<T>(string sql, object param = null) where T : class
		{
			using (var conn = ConnectionFactory.CreateConnection())
			{
				return conn.Query<T>(sql, param); 
			}
		}

		public int Execute(string sql, object param = null)
		{
			using (var conn = ConnectionFactory.CreateConnection())
			{
				return conn.Execute(sql, param);
			}
		}
	}
}
