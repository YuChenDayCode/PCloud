using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Framework.Data.ORM
{
    /// <summary>
    /// Mysql sql 构造
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MysqlConstructor<T> : Constructor<T>
    {
        protected override string BuildInsert(IEnumerable<IPropertyMap> propertys)
        {
            //过滤了为null的数据
            var kv = (from t in propertys where t.PropertyInfo.GetValue(this.entity) != null select new KeyValuePair<string, string>(t.ColumnName, t.GetParamName())).ToDictionary(k => $"`{k.Key}`", v => v.Value);
            return $"({string.Join(",", kv.Keys)}) values ({string.Join(",", kv.Values)})";
        }

        protected override IEnumerable<KeyValuePair<string, object>> GetParameter()
        {
            var para = new Dictionary<string, object>();
            if (this.entity != null)
            {
                foreach (var item in this.property)
                {
                    if (!para.ContainsKey(item.GetParamName()))
                    {
                        var value = item.PropertyInfo.GetValue(this.entity);
                        para.Add(item.GetParamName(), value);
                    }
                }
            }
            return para;
        }
    }
}
