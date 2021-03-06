﻿using Myn.Core.AppSettingManager;
using Myn.Data.ORM;
using System;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

namespace Myn.Data.ORM
{
    public class SqlServerDbConnectConfig : ConfigManager<SqlServerDbConntionConfigureItem>
    {
        static SqlServerDbConnectConfig sqlServerDbConnectConfig;
        readonly static object obj = new object();
        private SqlServerDbConnectConfig() { }
        public static string GetSqlDbConntionConfigure()
        {
            lock (obj)
            {
                if (sqlServerDbConnectConfig == null)
                {
                    sqlServerDbConnectConfig = new SqlServerDbConnectConfig();
                    return sqlServerDbConnectConfig.LoadConfig();
                }
                return sqlServerDbConnectConfig.LoadConfig();
            }
        }

        public string LoadConfig()
        {
            string configPath = AppSettingConfig.GetAppSetting()["AppSetting:sqlconfigPath"];
            XDocument xDoc = this.LocalConfig(configPath);
            var sc = from t in xDoc.Root.Elements("sqlconntionitem")
                     select SqlServerDbConnectConfig.CreaterConfigureItem(t);
            var s = sc.First();

            return sc.First().ToString();
        }
    }
}

public class SqlServerDbConntionConfigureItem : IDBConfig
{
    public string Host { get; set; }
    public string Port { get; set; }
    public string DbName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Key { get; internal set; }


    public override string ToString()
    {
        return $"Data Source={this.Host} {(string.IsNullOrWhiteSpace(this.Port) ? string.Empty : $",{ this.Port}")}; Initial Catalog={DbName}; User ID={UserName}; Password={Password};Pooling=true;Max Pool Size=40000;Min Pool Size=0 ";
    }
}