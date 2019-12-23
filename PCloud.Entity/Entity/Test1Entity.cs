using System;
using System.Collections.Generic;
using System.Text;
using Myn.Data.ORM;

namespace PCloud.Entity.Entity
{
    [EntityMapper_TableName("test1")]
   public class Test1Entity
    {
        [PrimaryKey(PrimaryType.Increment)]
        public int Id { get; set; }
        public string test { get; set; }
        public DateTime? ct { get; set; }
    }
}
