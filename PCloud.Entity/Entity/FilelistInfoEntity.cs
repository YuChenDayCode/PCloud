using Myn.Data.ORM;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCloud.Entity.Entity
{
    [EntityMapper_TableName("c_file_info")]
    public class FilelistInfoEntity
    {
        [PrimaryKey(PrimaryType.Increment)]
        public int Id { get; set; }
        public string c_file_name { get; set; }
        [EntityMapper_Ignore]
        public string c_file_test_ignore { get; set; }

        [EntityMapper_ColumnName("c_file_desc")]
        public string FileDesc { get; set; }

        public int c_file_upload_number { get; set; }

        public DateTime c_file_create_time { get; set; }
        public DateTime c_file_upload_time { get; set; }

        public bool c_file_isdel { get; set; }

    }
}
