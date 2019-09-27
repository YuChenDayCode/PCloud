using Framework.Data.ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Framework.Data.ORM
{
    public enum DMLType
    {
        Insert = 1,
        Update = 2,
        Delete = 3
    }

    /// <summary>
    /// 构造增删改
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Constructor<T>
    {
        readonly EntityMapper<T> entitymap;
        private DMLType _DMLType;
        protected T entity;
        protected IEnumerable<IPropertyMap> property;
        private Func<IEnumerable<IPropertyMap>, string> format;
        protected Where _where;
        public Constructor()
        {
            this.entitymap = new EntityMapper<T>();
        }
        public Constructor<T> Insert(T entity)
        {
            _DMLType = DMLType.Insert;
            this.entity = entity;
            this.property = from t in this.entitymap.PropertyMaps
                            where t.PrimaryKey == null && t.Ignore == false
                            select t;
            this.format = new Func<IEnumerable<IPropertyMap>, string>(BuildInsert);
            return this;
        }
        public Constructor<T> Update(T entity)
        {
            _DMLType = DMLType.Update;
            this.entity = entity;
            this.property = from t in this.entitymap.PropertyMaps
                            where t.PrimaryKey == null && t.Ignore == false
                            select t;
            this.format = new Func<IEnumerable<IPropertyMap>, string>(BuildUpdate);
            return this;
        }
        public Constructor<T> Update(T entity,params string[] arrs)
        {
            _DMLType = DMLType.Update;
            var partmap = from t in this.entitymap.PropertyMaps where arrs.Contains(t.Name) select t;
            this.entity = entity;
            this.property = from t in partmap
                            where t.PrimaryKey == null && t.Ignore == false
                            select t;
            this.format = new Func<IEnumerable<IPropertyMap>, string>(BuildUpdate);
            return this;
        }

        public Constructor<T> where(Expression<Func<T, object>> expressions)
        {
            _where = Where.Parse(expressions, this.entitymap.PropertyMaps);
            return this;
        }
       

        /// <summary>
        /// 构造语句
        /// </summary>
        /// <returns></returns>
        public IContainer Build()
        {
            var sql = new StringBuilder();
            sql.Append($"{this._DMLType} {this.entitymap.TabelName} {(this.format == null ? string.Empty : format(this.property))}");
            if (_where != null)
            {
                sql.Append($" where {_where.ToString()}");
            }
            return new UnityContainer() { Sql = sql.ToString(), CommandType = CommandType.Text, Parameters = this.GetParameter() };
        }


        protected abstract string BuildInsert(IEnumerable<IPropertyMap> propertys);
        protected abstract string BuildUpdate(IEnumerable<IPropertyMap> propertys);

        protected abstract IEnumerable<KeyValuePair<string, object>> GetParameter();
    }
}
