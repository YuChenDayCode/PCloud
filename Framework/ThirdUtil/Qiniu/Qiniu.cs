using System;
using System.Collections.Generic;
using System.Text;

namespace Myn.ThirdUtil.Qiniu
{
    public class Qiniu:IQiniu
    {
        public string UploadFile(string FileName, string BucketName)
        {
            UploadManage um = new UploadManage();
            return um.UploadFile(FileName, BucketName);
        }

        public string CreatePrivateUrl(string FileName, string Domain)
        {
            DownloadManage dm = new DownloadManage();
            return dm.CreatePrivateUrl(FileName, Domain);
        }

    }

}


