using Dapper.Contrib.Extensions;

namespace Dapper.Extension
{
	public class TranDBManager : IDBManager
	{
		public T GetById<T>(dynamic id) where T : class
		{
			using (var conn = ConnectionFactory.CreateTransactedConnection())
			{
				return conn.Get<T>(id as object);
			}
		}
	}
}
