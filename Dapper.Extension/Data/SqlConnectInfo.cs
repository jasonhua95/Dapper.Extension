using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Data
{
	/// <summary>
	/// 读取数据库连接字符串后装载连接信息的类型
	/// </summary>
	public class SqlConnectInfo
	{
		/// <summary>
		/// 连接字符串
		/// </summary>
		public String ConnectionString { get; set; }
		/// <summary>
		/// 连接提供程序名称
		/// </summary>
		public String ProviderName { set; get; }
	}
}
