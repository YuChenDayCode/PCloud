using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace Myn.Data.ORM
{
    public abstract class Query<T>
    {
        protected readonly EntityMapper<T> entitymap;
        protected IEnumerable<IPropertyMap> propertyMaps;
        protected Where _where;
        protected SqlCount _sqlCount;

        public abstract Query<T> Top(int num);
        public abstract Query<T> where(Expression<Func<T, object>> expression);
        public abstract Query<T> Count(Expression<Func<T, object>> expression);
        public abstract ISqlDocker Build();

        public Query()
        {
            this.entitymap = new EntityMapper<T>();
            this.propertyMaps = from t in entitymap.PropertyMaps where t.Ignore == false select t;
        }
    }

    public class SqlCount
    {
        readonly string _CountSql;
        public string CountSql => _CountSql;
        public SqlCount(string _conuntSql)
        {
            _CountSql = _conuntSql;
        }
    }
}
