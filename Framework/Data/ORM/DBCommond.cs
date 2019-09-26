using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Framework.Data.ORM
{
    public abstract class DBCommond
    {
        readonly IDBConnect conn;
        protected IDBConnect Connect => conn;
        public DBCommond()
        {
            this.conn = this.GetIDbConntion();

        }
        protected abstract IDBConnect GetIDbConntion();
        protected abstract void SetParameter(IDataParameterCollection mysqlpara, IEnumerable<KeyValuePair<string, object>> Parameters);

        public IDbCommand CreateCommond(IContainer container)
        {
            var cmd = this.conn.GetIDbCommand();
            cmd.CommandText = container.Sql;
            cmd.CommandType = container.CommandType;
            this.SetParameter(cmd.Parameters, container.Parameters);
            return cmd;
        }



        public void ExecuteNonQuery(IContainer container, out int row)
        {
            IDbCommand cmd = CreateCommond(container);
            try
            {
                row = cmd.ExecuteNonQuery();
            }
            //catch (Exception ex) { }
            finally
            {
                CloseConn(this.conn);
            }
        }
        private void CloseConn(IDBConnect con)
        {
            con.Close();
        }

    }
}
