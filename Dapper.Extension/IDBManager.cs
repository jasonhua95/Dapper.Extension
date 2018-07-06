using System.Collections.Generic;

namespace Dapper.Extension
{
	public interface IDBManager
	{
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="t"></param>
		/// <returns>id</returns>
		long Insert<T>(T t) where T : class;

		/// <summary>
		/// 插入数据
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="list"></param>
		/// <returns>id</returns>
		long Insert<T>(IEnumerable<T> list) where T : class;

		/// <summary>
		/// 更新数据
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="t"></param>
		/// <returns>成功：失败</returns>
		bool Update<T>(T t) where T : class;

		/// <summary>
		/// 更新数据
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="list"></param>
		/// <returns>成功：失败</returns>
		bool Update<T>(IEnumerable<T> list) where T : class;

		/// <summary>
		/// 删除数据
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="id"></param>
		/// <returns></returns>
		bool Delete<T>(dynamic id) where T : class;

		/// <summary>
		/// 删除数据
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="id"></param>
		/// <returns></returns>
		bool Delete<T>(IEnumerable<dynamic> idList) where T : class;

		/// <summary>
		/// 获取实体数据
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="id">id</param>
		/// <returns>实体数据</returns>
		T GetById<T>(dynamic id) where T : class;

		/// <summary>
		/// 获取所有数据
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <returns>所有数据</returns>
		IEnumerable<T> GetAll<T>() where T : class;

		/// <summary>
		/// 执行查询操作
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="sql">sql</param>
		/// <param name="param">参数</param>
		/// <returns></returns>
		IEnumerable<T> Query<T>(string sql, object param = null) where T : class;

		/// <summary>
		/// 执行增删改操作
		/// </summary>
		/// <param name="sql">sql</param>
		/// <param name="param">参数</param>
		/// <returns>执行的条数</returns>
		int Execute(string sql, object param = null);
	}
}
