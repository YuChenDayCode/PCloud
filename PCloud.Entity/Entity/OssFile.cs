using Myn.Data.ORM;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCloud.Entity.Entity
{
    [EntityMapper_TableName("c_ossfile")]
    public class OssFile
    {
        [PrimaryKey(PrimaryType.Increment)]
        public int Id { get; set; }
        public string FileKey { get; set; }
        public string FileHash { get; set; }
        public string FileDomain { get; set; }
    }
}
