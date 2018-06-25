using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Data
{
	public interface IDbSession : IDbConnection
	{
		void Commit();
	}

	public abstract class DbSessionBase : IDbSession
	{
		public abstract string ConnectionString { set; get; }

		public abstract int ConnectionTimeout { get; }

		public abstract string Database { get; }

		public abstract ConnectionState State { get; }
		[Obsolete("该方法已经停用，直接创建该抽象类子类实例即可开启事务")]
		public virtual IDbTransaction BeginTransaction()
		{
			throw new NotImplementedException("BeginTransaction");
		}
		[Obsolete("该方法已经停用，直接创建该抽象类子类实例即可开启事务")]
		public virtual IDbTransaction BeginTransaction(IsolationLevel il)
		{
			throw new NotImplementedException("BeginTransaction");
		}

		public abstract void ChangeDatabase(string databaseName);

		public abstract void Close();

		public abstract void Commit();

		public abstract IDbCommand CreateCommand();

		public abstract void Dispose();

		public abstract void Open();
	}
}
