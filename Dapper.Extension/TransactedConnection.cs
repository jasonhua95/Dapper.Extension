using System;
using System.Data;

namespace Dapper.Extension
{
	public class TransactedConnection : IDbConnection
	{
		private IDbConnection _conn;
		private IDbTransaction _tran;
		private IsolationLevel _level;

		public TransactedConnection(IDbConnection conn)
		{
			_conn = conn;
			Open();
		}

		public TransactedConnection(IDbConnection conn, IsolationLevel level)
		{
			_conn = conn;
			_level = level;
			Open();
		}

		public string ConnectionString
		{
			get { return _conn.ConnectionString; }
			set { _conn.ConnectionString = value; }
		}

		public int ConnectionTimeout => _conn.ConnectionTimeout;
		public string Database => _conn.Database;
		public ConnectionState State => _conn.State;

		public IDbTransaction BeginTransaction(IsolationLevel il)
		{
			throw new NotImplementedException();
		}

		public IDbTransaction BeginTransaction() => _tran;

		public void ChangeDatabase(string databaseName) => _conn.ChangeDatabase(databaseName);

		public void Close() => _conn.Close();

		public void Dispose() => _conn.Dispose();

		public IDbCommand CreateCommand()
		{
			// The command inherits the "current" transaction.
			var command = _conn.CreateCommand();
			command.Transaction = _tran;
			return command;
		}

		public void Open()
		{
			if (_conn.State == ConnectionState.Closed)
			{
				_conn.Open();
			}
			if (_level != 0)
			{
				_tran = _conn.BeginTransaction(_level);
			}
			else
			{
				_tran = _conn.BeginTransaction();
			}
		}

		public void Commit()
		{
			if (_tran != null)
			{
				_tran.Commit();
				_tran.Dispose();
			}
		}

		public void Rollback()
		{
			if (_tran != null)
			{
				_tran.Rollback();
				_tran.Dispose();
			}
		}

	}
}
