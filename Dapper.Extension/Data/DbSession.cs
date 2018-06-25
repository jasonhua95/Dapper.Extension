using System;
using System.Data;
using System.Data.SqlClient;

namespace Store.Core.Data
{
	public sealed class DbSession : DbSessionBase
	{
		private IDbConnection _internal = null;
		private IDbTransaction _transaction = null;
		private IsolationLevel _level = 0;

		public DbSession(String connstr)
		{
			this._internal = new SqlConnection(connstr);
		}

		public DbSession(String connstr, IsolationLevel level)
		{
			this._level = level;
			this._internal = new SqlConnection(connstr);
		}

		public override string ConnectionString
		{
			get
			{
				return this._internal.ConnectionString;
			}

			set
			{
				this._internal.ConnectionString = value;
			}
		}

		public override int ConnectionTimeout
		{
			get
			{
				return this._internal.ConnectionTimeout;
			}
		}

		public override string Database
		{
			get
			{
				return this._internal.Database;
			}
		}

		public override ConnectionState State
		{
			get
			{
				return this._internal.State;
			}
		}

		public override void ChangeDatabase(string databaseName)
		{
			this._internal.ChangeDatabase(databaseName);
		}

		public override void Close()
		{
			if(this._transaction != null)
			{
				this._transaction.Rollback();
				this._transaction.Dispose();
				this._transaction = null;
				this._level = 0;
			}
			this._internal.Close();
		}
		
		public override void Commit()
		{
			if(this._transaction != null)
			{
				this._transaction.Commit();
                this._transaction.Dispose();
                this._transaction = null;
				this._level = 0;
			}
		}

		public override IDbCommand CreateCommand()
		{
			IDbCommand command = this._internal.CreateCommand();
			if (this._transaction != null)
			{
				command.Transaction = this._transaction;
			}
			return command;
		}

		public override void Dispose()
		{
			if (this._transaction != null)
			{
				this._transaction.Rollback();
				this._transaction.Dispose();
				this._transaction = null;
				this._level = 0;
			}
			this._internal.Dispose();
		}

		public override void Open()
		{
			if(this._internal.State == ConnectionState.Closed)
			{
				this._internal.Open();
			}
			//该会话类型默认会开启事务，所以当连接关闭之后，再次打开连接时，应该开启事务
			if(this._transaction == null)
			{
				if(this._level != 0)
					this._transaction = this._internal.BeginTransaction(this._level);
				else
					this._transaction = this._internal.BeginTransaction();
			}
		}
	}
}
