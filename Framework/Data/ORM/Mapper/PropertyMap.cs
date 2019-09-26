using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Framework.Data.ORM;

namespace Framework.Data.ORM
{
    public class PropertyMap<T> : IPropertyMap
    {
        public PropertyInfo PropertyInfo { get; }
        public Type DataType => PropertyInfo.PropertyType;

        public bool Ignore { get; }

        public string ColumnName { get; }

        public PrimaryKey PrimaryKey { get; }

        public string Name => PropertyInfo.Name;

        readonly string tableName;

        public PropertyMap(PropertyInfo propertyInfo, string tableName)
        {
            this.PropertyInfo = propertyInfo;
            this.tableName = tableName;
            this.Ignore = GetIgnoreAttribute(propertyInfo);
            this.PrimaryKey = propertyInfo.GetCustomAttribute<PrimaryKey>();
            this.ColumnName = GetColumnAttribute(propertyInfo);
        }

        static bool GetIgnoreAttribute(PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttribute<EntityMapper_Ignore>() != null;
        }
        static string GetColumnAttribute(PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttribute<EntityMapper_ColumnName>()?.AliasName ?? propertyInfo.Name;
        }
        static PrimaryKey GetPrimaryKeyAttribute(PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttribute<PrimaryKey>();
        }

        public string GetParamName(string paramMark = "@")
        {
            return $"{paramMark}{GetMapperColumnName("_")}";
        }

        public string GetMapperColumnName(string split = ".")
        {
            return $"{tableName}{split}{this.ColumnName}";
        }
    }
}
