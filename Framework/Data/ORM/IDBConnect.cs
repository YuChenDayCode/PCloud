using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Framework.Data.ORM
{
    public interface IDBConnect
    {
        IDbConnection GetIDbConnection();
        IDbCommand GetIDbCommand();

        void Close();
    }
}
