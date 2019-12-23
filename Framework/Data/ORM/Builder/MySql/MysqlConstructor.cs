using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Myn.Data.ORM
{
    /// <summary>
    /// Mysql sql 构造
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MysqlConstructor<T> : Constructor<T>
    {
        protected override string BuildBatchInsert(IEnumerable<IPropertyMap> propertys)
        {
            StringBuilder batch = new StringBuilder();
            int c = 0;
            foreach (var item in this.list)
            {
                c++;
                var kv = (from t in propertys where t.PropertyInfo.GetValue(item) != null 
                          select new KeyValuePair<string, string>(t.GetManyParamName(c.ToString()),t.Name)).ToDictionary(k => k.Key, v => v.Value);
                batch.Append(this._DMLType.ToString());
                batch.Append(this.entitymap.TabelName.Fill());
                batch.Append($"({ string.Join(",", kv.Values)}) VALUES ({ string.Join(",", kv.Keys) });\n");
            }
            string a = batch.ToString();
            return a;
        }

        protected override string BuildInsert(IEnumerable<IPropertyMap> propertys)
        {
            //过滤了为null的数据
            var kv = (from t in propertys where t.PropertyInfo.GetValue(this.entity) != null
                      select new KeyValuePair<string, string>(t.ColumnName, t.GetParamName())).ToDictionary(k => $"`{k.Key}`", v => v.Value);
            return $" ({string.Join(",", kv.Keys)}) VALUES ({string.Join(",", kv.Values)})";
        }
        protected override string BuildInsert_Return_Id(IEnumerable<IPropertyMap> propertys)
        {
            string insert_sql = BuildInsert(propertys);
            return $"{insert_sql};SELECT LAST_INSERT_ID();";
        }


        protected override string BuildUpdate(IEnumerable<IPropertyMap> propertys)
        {
            var u = from t in propertys select $"`{t.ColumnName}`= {t.GetParamName()}";
            return $" SET {string.Join(",", u)} ";
        }

        protected override IEnumerable<KeyValuePair<string, object>> GetParameter()
        {
            var para = new Dictionary<string, object>();
            if (_where != null)
            {
                string str = _where.ToString();
                var dic = new Dictionary<string, object>();
                _where.GetDictionary(dic);
                foreach (var item in dic)
                {
                    if (!para.ContainsKey(item.Key))
                    {
                        para.Add(item.Key, item.Value);
                    }
                }
            }

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
            if (this.list?.Count() > 0)
            {
                int c = 0;
                foreach (var entity in this.list)
                {
                    c++;
                    foreach (var item in this.property)
                    {
                        string ParaName = item.GetManyParamName(c + "");
                        if (!para.ContainsKey(ParaName))
                        {
                            var value = item.PropertyInfo.GetValue(entity);
                            para.Add(ParaName, value);
                        }
                    }
                }

            }
            return para;
        }
    }
}
