using Framework.Data.ORM;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCloud.Entity.Entity
{
    [EntityMapper_TableName("c_filelist_info")]
    public class FilelistInfoEntity
    {
        [PrimaryKey(PrimaryType.Increment)]
        public int Id { get; set; }
        public string c_file_name { get; set; }
        [EntityMapper_Ignore]
        public string c_file_name1 { get; set; }
        [EntityMapper_Ignore]
        public string c_file_name2 { get; set; }
        [EntityMapper_Ignore]
        public string c_file_name3 { get; set; }
        [EntityMapper_Ignore]
        public string c_file_name4 { get; set; }
        [EntityMapper_ColumnName("c_file_desc")]
        public string FileDesc { get; set; }

        public int c_file_upload_number { get; set; }


    }
}
