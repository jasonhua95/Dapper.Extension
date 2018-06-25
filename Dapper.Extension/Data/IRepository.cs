using System.Collections.Generic;
using Dapper;

namespace Store.Core.Data
{
	public interface IRepository
	{
		/// <summary>
		/// Get entity by identifier
		/// </summary>
		/// <param name="id">Identifier</param>
		/// <returns>Entity</returns>
		T GetById<T>(object id) where T : ObjectEntity;

		/// <summary>
		/// Insert entity
		/// </summary>
		/// <param name="entity">Entity</param>
		dynamic Insert<T>(T entity) where T : ObjectEntity;

		/// <summary>
		/// Insert entities
		/// </summary>
		/// <param name="entities">Entities</param>
		void Insert<T>(IEnumerable<T> entities) where T : ObjectEntity;

		/// <summary>
		/// Update entity
		/// </summary>
		/// <param name="entity">Entity</param>
		bool Update<T>(T entity) where T : ObjectEntity;

		/// <summary>
		/// Delete entity
		/// </summary>
		/// <param name="entity">Entity</param>
		int Delete<T>(T entity) where T : ObjectEntity;

		/// <summary>
		/// 执行SQL语句获取数据集合
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="sql"></param>
		/// <param name="param"></param>
		/// <param name="buffered"></param>
		/// <returns></returns>
		IEnumerable<T> Query<T>(string sql, dynamic param = null, bool buffered = false) ;
        IEnumerable<dynamic> Query(string sql, dynamic param = null, bool buffered = false);

        /// <summary>
        /// 执行SQL语句获取数据集合中的第一个结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        T GetFirst<T>(string sql, dynamic param = null, bool buffered = false) ;
        dynamic GetFirst(string sql, dynamic param = null, bool buffered = false);

		

	

	
        // <summary>
        /// 获取数据全部列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        IList<T> GetList<T>() where T : ObjectEntity;

        /// <summary>
        /// 执行SQL语句获取数据列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        IList<T> GetList<T>(string sql, dynamic param = null, bool buffered = false) ;
        IList<dynamic> GetList(string sql, dynamic param = null, bool buffered = false);

        /// <summary>
        /// 统计记录总数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        int Count(string sql, dynamic param = null) ;

		/// <summary>


        /// <summary>
        /// 分页方法，返回动态类型
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="param">动态参数</param>
        /// <param name="countSql">获取记录数SQL</param>
        /// <returns></returns>
        IEnumerable<T> GetPaged<T>(string sql, int pageIndex, int pageSize, out long total, DynamicParameters param = null, string countSql = null) where T : class;
        IEnumerable<dynamic> GetPaged(string sql, int pageIndex, int pageSize, out long total, DynamicParameters param = null, string countSql = null); 

		/// <summary>
		/// 执行sql操作
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="param"></param>
		/// <returns></returns>
		int ExecuteSql(string sql, dynamic param = null);

		/// <summary>
		/// 执行存储过程
		/// </summary>
		/// <param name="procName"></param>
		/// <param name="param"></param>
		/// <returns></returns>

		int ExecuteProcedure(string procName, DynamicParameters param = null) ;
	}
}