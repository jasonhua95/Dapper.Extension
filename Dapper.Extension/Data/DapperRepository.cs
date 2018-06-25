//using System.Collections.Generic;
//using System.Linq;
//using System.Data;
//using Dapper;
//using Dapper.Contrib.Extensions;

//namespace Store.Core.Data
//{
//	public class DapperRepository : IRepository
//    {
//        /// <summary>
//        /// Get entity by identifier
//        /// </summary>
//        /// <param name="id">Identifier</param>
//        /// <returns>Entity</returns>
//        public T GetById<T>(object id) where T : class
//		{
//            using (IDbConnection conn = ConnectionFactory.CreateConnection())
//            {
//                return conn.Get<T>(id as object);
//            }
//        }

//        /// <summary>
//        /// Insert entity
//        /// </summary>
//        /// <param name="entity">Entity</param>
//        public dynamic Insert<T>(T entity) where T : class
//		{
//            using (IDbConnection conn = ConnectionFactory.CreateConnection())
//            {
//                return conn.Insert<T>(entity);
//            }
//        }

//        /// <summary>
//        /// Insert entities
//        /// </summary>
//        /// <param name="entities">Entities</param>
//        public void Insert<T>(IEnumerable<T> entities) where T : class
//		{
//            using (IDbConnection conn = ConnectionFactory.CreateConnection())
//            {
//                conn.Insert<T>(entities);
//            }
//        }

//        /// <summary>
//        /// Update entity
//        /// </summary>
//        /// <param name="entity">Entity</param>
//        public bool Update<T>(T entity) where T : class
//		{
//            using (IDbConnection conn = ConnectionFactory.CreateConnection())
//            {
//                return conn.Update<T> (entity);
//            }
//        }



//        /// <summary>
//        /// Delete entity
//        /// </summary>
//        /// <param name="entity">Entity</param>
//        public int Delete<T>(T entity) where T : class
//		{
//            using (IDbConnection conn = ConnectionFactory.CreateConnection())
//            {
//                return conn.Delete<T>(entity);
//            }
//        }


//        /// <summary>
//        /// 执行SQL语句获取数据集合
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="sql"></param>
//        /// <param name="param"></param>
//        /// <param name="buffered"></param>
//        /// <returns></returns>

//        public IEnumerable<T> Query<T>(string sql, dynamic param = null, bool buffered = false)
//		{
//            using (IDbConnection conn = ConnectionFactory.CreateConnection())
//            {
//                return conn.Query<T>(sql, param as object, null, buffered).ToList();

//            }
//        }
//        public IEnumerable<dynamic> Query(string sql, dynamic param = null, bool buffered = false)
//        {
//            using (IDbConnection conn = ConnectionFactory.CreateConnection())
//            {
//                return conn.Query(sql, param as object, null, buffered).ToList();
//            }
//        }

//        /// <summary>
//        /// 执行SQL语句获取数据集合中的第一个结果
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="sql"></param>
//        /// <param name="param"></param>
//        /// <param name="buffered"></param>
//        /// <returns></returns>


//        public T GetFirst<T>(string sql, dynamic param = null, bool buffered = false)
//		{
//            using (IDbConnection conn = ConnectionFactory.CreateConnection())
//            {
//                T entity = default(T);
//                var list = conn.Query<T>(sql, param as object, null, buffered).ToList<T>();
//                if (list != null && list.Count() > 0)
//                {
//                    entity = list[0];
//                }
//                return entity;
//            }
//        }

//        public dynamic GetFirst(string sql, dynamic param = null, bool buffered = false)
//        {
//            using (IDbConnection conn = ConnectionFactory.CreateConnection())
//            {               
//                var list = conn.Query(sql, param as object, null, buffered).ToList();
//                if (list != null && list.Count() > 0)
//                {
//                    dynamic entity = list[0];
//                    return entity;
//                }
//                return null;
//            }
//        }

//        // <summary>
//        /// 获取数据全部列表
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="sql"></param>
//        /// <param name="param"></param>
//        /// <param name="buffered"></param>
//        /// <returns></returns>
//        public IList<T> GetList<T>() where T : class
//        {
//            using (IDbConnection conn = ConnectionFactory.CreateConnection())
//            {
//                var query = conn.GetList<T>();
//                if (query != null)
//                    return query.ToList<T>();
//                return default(IList<T>);
//            }
//        }
       


//        /// <summary>
//        /// 执行SQL语句获取数据列表
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="sql"></param>
//        /// <param name="param"></param>
//        /// <param name="buffered"></param>
//        /// <returns></returns>

//        public IList<T> GetList<T>(string sql, dynamic param = null, bool buffered = false)
//		{
//            using (IDbConnection conn = ConnectionFactory.CreateConnection())
//            {
//                var query=conn.Query<T>(sql, param as object, null, buffered);
//                if (query != null)
//                    return query.ToList<T>();
//                return default(IList<T>);
//            }
//        }

//        public IList<dynamic> GetList(string sql, dynamic param = null, bool buffered = false)
//        {
//            using (IDbConnection conn = ConnectionFactory.CreateConnection())
//            {
//                var query = conn.Query(sql, param as object, null, buffered);
//                if (query != null)
//                    return query.ToList();
//                return default(IList<dynamic>);
//            }
//        }

//        /// <summary>
//        /// 统计记录总数
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="sql"></param>
//        /// <param name="param"></param>
//        /// <param name="buffered"></param>
//        /// <returns></returns>

//        public int Count(string sql, dynamic param = null)
//		{
//            using (IDbConnection conn = ConnectionFactory.CreateConnection())
//            {
//                return conn.Query<int>(sql, param as object).Single<int>();
//            }
//        }

//        /// <summary>
//        /// 分页方法，返回动态类型
//        /// </summary>
//        /// <param name="sql"></param>
//        /// <param name="pageIndex"></param>
//        /// <param name="pageSize"></param>
//        /// <param name="param">动态参数</param>
//        /// <param name="countSql">获取记录数SQL</param>
//        /// <returns></returns>
//        public IEnumerable<dynamic> GetPaged(string sql, int pageIndex, int pageSize, out long total, DynamicParameters param = null, string countSql = null)
//		{
//            using (IDbConnection conn = ConnectionFactory.CreateConnection())
//            {
//                return conn.GetPage(pageIndex, pageSize, out total, sql, param, countSql).ToList();
//            }
//        }

//        public IEnumerable<T> GetPaged<T>(string sql, int pageIndex, int pageSize, out long total, DynamicParameters param = null, string countSql = null) where T : class
//        {
//            using (IDbConnection conn = ConnectionFactory.CreateConnection())
//            {
//                return conn.GetPage<T>(pageIndex, pageSize, out total, sql, param, countSql).ToList();
//            }
//        }

//        /// <summary>
//        /// 执行sql操作
//        /// </summary>
//        /// <param name="sql"></param>
//        /// <param name="param"></param>
//        /// <returns></returns>

  
//        public int ExecuteSql(string sql, dynamic param = null)
//		{
//            using (IDbConnection conn = ConnectionFactory.CreateConnection())
//            {
//                return conn.Execute(sql, param as object, null);
//            }
//        }

//        /// <summary>
//        /// 执行存储过程
//        /// </summary>
//        /// <param name="procName"></param>
//        /// <param name="param"></param>
//        /// <returns></returns>
//        public int ExecuteProcedure(string procName, DynamicParameters param = null)
//		{
//            using (IDbConnection conn = ConnectionFactory.CreateConnection())
//            {
//                return conn.Execute(procName, param, null, null, CommandType.StoredProcedure);
//             }
//        }
//    }

//}
