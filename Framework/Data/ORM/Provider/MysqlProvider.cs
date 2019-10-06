using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace Myn.Data.ORM
{
    public class MysqlProvider<T> : DBProvider<T>, IDbProvider<T> where T : new()
    {

        public MysqlProvider() : base() { }

        #region Contructor
        protected override Constructor<T> CreateContructor()
        {
            return new MysqlConstructor<T>();
        }

        protected override DBCommond CreateExecute()
        {
            return new MysqlContainer();
        }

        protected override Query<T> CreateQuery()
        {
            return new MysqlQuery<T>();
        }

        protected override IDbConnect GetIDbConntion()
        {
            return new MySqlDbConnect();
        }

        #endregion

        public T Get()
        {
            var q = this.CreateQuery().Build();
            return this.dbExecute.ExecuteReader<T>(q).FirstOrDefault();
        }

        public T Get(Expression<Func<T, object>> exp)
        {
            var q = this.CreateQuery().where(exp).Build();
            return this.dbExecute.ExecuteReader<T>(q).FirstOrDefault();
        }

        public bool Insert(T entity)
        {
            int row;
            var docker = this.CreateContructor().Insert(entity).Build();
            this.dbExecute.ExecuteNonQuery(docker, out row);
            return row > 0;
        }
        public void Insert_Return_Id(T entity, out int Id)
        {
            var docker = this.CreateContructor().Insert_Return_Id(entity).Build();
            this.dbExecute.ExecuteScalar<int>(docker, out Id);
        }

    }
}
