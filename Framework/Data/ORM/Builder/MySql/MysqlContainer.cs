using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Framework.Data.ORM
{
    public class MysqlContainer : DBCommond
    {
        readonly IDbConnection conn;
        protected IDbConnection Conntion => conn;
        public MysqlContainer() : base()
        {
        }

        protected override IDBConnect GetIDbConntion()
        {
            return new MySqlDbConnect();
        }

        protected override void SetParameter(IDataParameterCollection mysqlpara, IEnumerable<KeyValuePair<string, object>> Parameters)
        {
            foreach (var para in Parameters)
            {
                mysqlpara.Add(new MySqlParameter(para.Key, para.Value));
            }

        }
    }
}
