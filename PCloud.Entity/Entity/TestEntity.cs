using System;
using System.Collections.Generic;
using System.Text;
using Myn.Data.ORM;

namespace PCloud.Entity.Entity
{
    [EntityMapper_TableName("test")]
   public class TestEntity
    {
        [PrimaryKey(PrimaryType.Increment)]
        public int Id { get; set; }
        public string cont { get; set; }
        public DateTime? ct { get; set; }
    }
}
