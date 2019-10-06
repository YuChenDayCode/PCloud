using Myn.Reflection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Myn.Data.ORM
{
    public class MysqlQuery<T> : Query<T>
    {
        private int _top = -1;
        public override Query<T> Top(int num)
        {
            this._top = num;
            return this;
        }
        public override ISqlDocker Build()
        {
            var sql = new StringBuilder();
            if (_sqlCount != null) sql.Append(_sqlCount.CountSql);
            else sql.Append($"select {string.Join(",", from t in this.propertyMaps select t.GetQueryField())} from {this.entitymap.TabelName}");

            if (_where != null)
            {
                sql.Append($" where {_where.ToString()} ");
            }

            var topStr = this._top > -1 ? $" limit { this._top }" : string.Empty;
            sql.Append(topStr);


            var docker = new SqlDocker() { Sql = sql.ToString(), CommandType = CommandType.Text };
            if (_where != null)
            {
                var dic = new Dictionary<string, object>();
                _where.GetDictionary(dic);
                docker.Parameters = dic;
            }
            return docker;
        }

        public override Query<T> where(Expression<Func<T, object>> expression)
        {
            this._where = Where.Parse(expression, this.propertyMaps);
            return this;
        }

        public override Query<T> Count(Expression<Func<T, object>> expression = null)
        {
            string CountKey = expression == null ? this.propertyMaps.First(m => m.PrimaryKey != null).Name : ReflectionExtension.GetProperty(expression).Name;
            string sql = $"select count({ this.entitymap.TabelName}.{CountKey}) from {this.entitymap.TabelName}";
            _sqlCount = new SqlCount(sql);
            return this;

        }
    }


}
