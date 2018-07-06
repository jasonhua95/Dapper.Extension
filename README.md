# Dapper.Extension
对StackExchange/Dapper的简单扩充，底层操作数据库的基本上都不用写了，主要实现增删改查，事务的处理，其他复杂的用Dapper中的方法

``` C#
//初始化connectionString
ConnectionFactory.InitConnectionString();

//插入数据
db.Insert(new Dog { Id = Guid.NewGuid().ToString(), Name = "小红", Age = 2, Weight = 10 });

//更新数据
db.Update(dog);

//删除数据
db.Dalete(1);

//获取实体
db.GetById<Dog>(2);

//获取所有
db.GetAll<Dog>();

//执行复杂查询
db.Query<Dog>("select Id,Name,Age,Weight from Dogs;");

//执行复杂操作数据
db.Execute("update Dogs set Age=3 where Age is null");

//执行事务
using (var conn = ConnectionFactory.CreateTransactedConnection())
{
	try {
		conn.Query("select 1");
		conn.Commit();
	} catch (Exception ex) {
		conn.Rollback();
	}
}
```
