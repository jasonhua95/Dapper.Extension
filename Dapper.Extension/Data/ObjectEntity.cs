//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Reflection;
//using System.Linq.Expressions;
//using Dapper;
//using DapperExtensions;
//using DapperExtensions.Mapper;
//using Store.Utility.Helper;

//namespace Store.Core.Data
//{
//    public class ObjectEntity
//    {
//        public static PropertyMap Map<T>(IList<IPropertyMap> properties,Expression<Func<T, object>> expression) where T : ObjectEntity
//        {
//            PropertyInfo propertyInfo = ReflecTypeHelper.GetProperty(expression) as PropertyInfo;
//            PropertyMap result = new PropertyMap(propertyInfo);
//            properties.Add(result);
//            return result;
//        }
//    }
//}
