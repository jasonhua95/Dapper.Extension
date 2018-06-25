using Dapper.Contrib.Extensions;

namespace Dapper.Extension
{
	public class DBManager : IDBManager
	{
		public T GetById<T>(dynamic id) where T : class
		{
			using (var conn = ConnectionFactory.CreateConnection())
			{
				return conn.Get<T>(id as object);
			}
		}
	}
}
