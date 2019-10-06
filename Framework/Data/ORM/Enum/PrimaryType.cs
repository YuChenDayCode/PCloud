using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Myn.Data.ORM
{
    public enum PrimaryType
    {
        Empty = 0,

        /// <summary>
        /// 自增
        /// </summary>
        Increment = 1

    }
}
