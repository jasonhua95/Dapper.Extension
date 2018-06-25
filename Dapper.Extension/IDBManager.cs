namespace Dapper.Extension
{
	public interface IDBManager
	{
		T GetById<T>(object id) where T : class;
	}
}
