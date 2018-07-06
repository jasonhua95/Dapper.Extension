using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
	[Table("Dogs")]
	public class Dog
	{
		public int? Age { get; set; }
		[Key]
		public string Id { get; set; }
		public string Name { get; set; }
		public float? Weight { get; set; }

		//public int IgnoredProperty { get { return 1; } }
	}
}
