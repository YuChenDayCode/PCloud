﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Framework.Data.ORM
{
    /// <summary>
    /// 命令容器
    /// </summary>
    public interface IContainer
    {
        CommandType CommandType { get; set; }
        string Sql { get; set; }
        IEnumerable<KeyValuePair<string, object>> Parameters { get; set; }
    }

    public class UnityContainer : IContainer
    {
        public UnityContainer() { }
        public CommandType CommandType { get; set; }
        public string Sql { get; set; }
        public IEnumerable<KeyValuePair<string, object>> Parameters { get; set; }
    }
}
