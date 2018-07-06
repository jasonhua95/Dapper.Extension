using Dapper.Contrib.Extensions;

namespace Test
{
	[Table("Dogs")]
	public class Dog
	{
		//自增ID用[Key],不是自增的用ExplicitKey
		[ExplicitKey]
		public string Id { get; set; }
		public string Name { get; set; }
		public int? Age { get; set; }
		public float? Weight { get; set; }
	}
}
