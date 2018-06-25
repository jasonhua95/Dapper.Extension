using System.Collections.Generic;
using Dapper;
using System.Data;

namespace Store.Core.Data
{
	public interface ITranRepository
	{
		/// <summary>
		/// 创建连接
		/// </summary>      
		/// <returns></returns>
		IDbSession CreateDbSession();

		IDbSession CreateDbSession(IsolationLevel level);

		/// <summary>
		/// Get entity by identifier
		/// </summary>
		/// <param name="id">Identifier</param>
		/// <returns>Entity</returns>
		T GetById<T>(IDbSession conn, object id) where T : class;

		/// <summary>
		/// Insert entity
		/// </summary>
		/// <param name="entity">Entity</param>
		dynamic Insert<T>(IDbSession conn, T entity) where T : class;

		/// <summary>
		/// Insert entities
		/// </summary>
		/// <param name="entities">Entities</param>
		void Insert<T>(IDbSession conn, IEnumerable<T> entities) where T : class;

		/// <summary>
		/// Update entity
		/// </summary>
		/// <param name="entity">Entity</param>
		bool Update<T>(IDbSession conn, T entity) where T : class;

		/// <summary>
		/// Delete entity
		/// </summary>
		/// <param name="entity">Entity</param>
		int Delete<T>(IDbSession conn, T entity) where T : class;

		/// <summary>
		/// 执行SQL语句获取数据集合
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="sql"></param>
		/// <param name="param"></param>
		/// <param name="buffered"></param>
		/// <returns></returns>

		IEnumerable<T> Query<T>(IDbSession conn, string sql, object param = null, bool buffered = false) ;
        IEnumerable<dynamic> Query(IDbSession conn, string sql, object param = null, bool buffered = false);


        /// <summary>
        /// 执行SQL语句获取数据集合中的第一个结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        T GetFirst<T>(IDbSession conn, string sql, dynamic param = null, bool buffered = false) ;
        dynamic GetFirst(IDbSession conn, string sql, dynamic param = null, bool buffered = false);


        // <summary>
        /// 获取数据全部列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        IList<T> GetList<T>(IDbSession conn) where T : class;


        /// <summary>
        /// 执行SQL语句获取数据列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        IList<T> GetList<T>(IDbSession conn, string sql, dynamic param = null, bool buffered = false) ;
        IList<dynamic> GetList(IDbSession conn, string sql, dynamic param = null, bool buffered = false);


        /// <summary>
        /// 统计记录总数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        int Count(IDbSession conn, string sql, dynamic param = null) ;

		

        

		/// <summary>
		/// 分页方法，返回动态类型
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <param name="param">动态参数</param>
		/// <param name="countSql">获取记录数SQL</param>
		/// <returns></returns>
        IEnumerable<T> GetPaged<T>(IDbSession conn, string sql, int pageIndex, int pageSize, out long total, DynamicParameters param = null, string countSql = null) where T : class;
        IEnumerable<dynamic> GetPaged(IDbSession conn, string sql, int pageIndex, int pageSize, out long total, DynamicParameters param = null, string countSql = null) ;

		/// <summary>
		/// 执行sql操作
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="param"></param>
		/// <returns></returns>

		int ExecuteSql(IDbSession conn, string sql, dynamic param = null) ;

		/// <summary>
		/// 执行存储过程
		/// </summary>
		/// <param name="procName"></param>
		/// <param name="param"></param>
		/// <returns></returns>

		int ExecuteProcedure(IDbSession conn, string procName, DynamicParameters param = null) ;
	}
}