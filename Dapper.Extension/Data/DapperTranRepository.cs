//using System.Collections.Generic;
//using System.Linq;
//using System.Data;
//using Dapper;
//using Dapper.Contrib.Extensions;
//using System;

//namespace Store.Core.Data
//{
//	public class DapperTranRepository : ITranRepository
//	{
//		/// <summary>
//		/// 创建连接
//		/// </summary>      
//		/// <returns></returns>
//		public IDbSession CreateDbSession()
//		{
//			return ConnectionFactory.CreateDbSession();
//		}

//		public IDbSession CreateDbSession(IsolationLevel level)
//		{
//			return ConnectionFactory.CreateDbSession(level);
//		}

//		/// <summary>
//		/// Get entity by identifier
//		/// </summary>
//		/// <param name="id">Identifier</param>
//		/// <returns>Entity</returns>
//		public T GetById<T>(IDbSession conn, object id) where T : class
//		{
//			return conn.Get<T>(id as object);
//		}

//		/// <summary>
//		/// Insert entity
//		/// </summary>
//		/// <param name="entity">Entity</param>
//		public dynamic Insert<T>(IDbSession conn, T entity) where T : class
//		{
//			return conn.Insert<T>(entity);
//		}

//		/// <summary>
//		/// Insert entities
//		/// </summary>
//		/// <param name="entities">Entities</param>
//		public void Insert<T>(IDbSession conn, IEnumerable<T> entities) where T : class
//		{
//			conn.Insert<T>(entities);
//		}

//		/// <summary>
//		/// Update entity
//		/// </summary>
//		/// <param name="entity">Entity</param>
//		public bool Update<T>(IDbSession conn, T entity) where T : class
//		{
//			return conn.Update<T>(entity);

//		}

//		/// <summary>
//		/// 执行SQL语句获取数据集合
//		/// </summary>
//		/// <typeparam name="T"></typeparam>
//		/// <param name="sql"></param>
//		/// <param name="param"></param>
//		/// <param name="buffered"></param>
//		/// <returns></returns>

//		public IEnumerable<T> Query<T>(IDbSession conn, string sql, dynamic param = null, bool buffered = false)

//		{
//			return conn.Query<T>(sql, param as object, null, buffered).ToList();
//		}


//        public IEnumerable<dynamic> Query(IDbSession conn, string sql, dynamic param = null, bool buffered = false)
//        {
//            return conn.Query(sql, param as object, null, buffered).ToList();
//        }

  

//		/// <summary>
//		/// 执行SQL语句获取数据集合中的第一个结果
//		/// </summary>
//		/// <typeparam name="T"></typeparam>
//		/// <param name="sql"></param>
//		/// <param name="param"></param>
//		/// <param name="buffered"></param>
//		/// <returns></returns>
//		public T GetFirst<T>(IDbSession conn, string sql, dynamic param = null, bool buffered = false)
//		{
//			T entity = default(T);
//			var list = conn.Query<T>(sql, param as object, null, buffered).ToList();
//			if (list != null && list.Count() > 0)
//			{
//				entity = list[0];
//			}
//			return entity;
//		}

//        public dynamic GetFirst(IDbSession conn, string sql, dynamic param = null, bool buffered = false)
//        {          
//            var list = conn.Query(sql, param as object, null, buffered).ToList();
//            if (list != null && list.Count() > 0)
//            {
//                dynamic entity = list[0];
//                return entity;
//            }
//            return null;
//        }


//		/// <summary>
//		/// 执行SQL语句获取数据列表
//		/// </summary>
//		/// <typeparam name="T"></typeparam>
//		/// <param name="sql"></param>
//		/// <param name="param"></param>
//		/// <param name="buffered"></param>
//		/// <returns></returns>
//		public IList<T> GetList<T>(IDbSession conn, string sql, dynamic param = null, bool buffered = false)
//		{
//			var query = conn.Query<T>(sql, param as object, null, buffered);
//			if (query != null)
//				return query.ToList<T>();
//			return default(IList<T>);
//		}

//        public IList<dynamic> GetList(IDbSession conn, string sql, dynamic param = null, bool buffered = false)
//        {
//            var query = conn.Query(sql, param as object, null, buffered);
//            if (query != null)
//                return query.ToList();
//            return default(IList<dynamic>);
//        }

    
//		/// 统计记录总数
//		/// </summary>
//		/// <typeparam name="T"></typeparam>
//		/// <param name="sql"></param>
//		/// <param name="param"></param>
//		/// <param name="buffered"></param>
//		/// <returns></returns>
//		public int Count(IDbSession conn, string sql, dynamic param = null)
//		{
//			return conn.Query<int>(sql, param as object).Single<int>();
//		}

//        /// <summary>
//        /// 执行sql操作
//        /// </summary>
//        /// <param name="sql"></param>
//        /// <param name="param"></param>
//        /// <returns></returns>

//        public int ExecuteSql(IDbSession conn, string sql, dynamic param = null)
//		{
//			return conn.Execute(sql, param as object);
//		}

//		/// <summary>
//		/// 执行存储过程
//		/// </summary>
//		/// <param name="procName"></param>
//		/// <param name="param"></param>
//		/// <returns></returns>
//		public int ExecuteProcedure(IDbSession conn, string procName, DynamicParameters param = null)
//		{
//			return conn.Execute(procName, param, null, null, CommandType.StoredProcedure);
//		}

//		public int Delete<T>(IDbSession conn, T entity) where T : class
//		{
//			throw new NotImplementedException();
//		}

//		public IList<T> GetList<T>(IDbSession conn) where T : class
//		{
//			throw new NotImplementedException();
//		}

//		public IEnumerable<T> GetPaged<T>(IDbSession conn, string sql, int pageIndex, int pageSize, out long total, DynamicParameters param = null, string countSql = null) where T : class
//		{
//			throw new NotImplementedException();
//		}

//		public IEnumerable<dynamic> GetPaged(IDbSession conn, string sql, int pageIndex, int pageSize, out long total, DynamicParameters param = null, string countSql = null)
//		{
//			throw new NotImplementedException();
//		}
//	}
//}