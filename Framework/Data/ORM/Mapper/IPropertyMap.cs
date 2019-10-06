using Myn.Data.ORM;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Myn.Data.ORM
{
    public interface IPropertyMap
    {
        Type DataType { get; }

        PropertyInfo PropertyInfo { get; }
        /// <summary>
        /// 忽略
        /// </summary>
        bool Ignore { get; }


        string Name { get; }
        /// <summary>
        /// 映射名
        /// </summary>
        string ColumnName { get; }

        string TableName { get; }

        /// <summary>
        /// 主键信息
        /// </summary>
        PrimaryKey PrimaryKey { get; }

        string GetParamName(string paramMark = "@");
        string GetMapperColumnName(string split = ".");
        string GetQueryField();
    }
}
