using Qiniu.Http;
using Qiniu.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Myn.ThirdUtil.Qiniu
{
    public interface IQiniu
    {
        string CreatePrivateUrl(string FileName, string Domain = "");
        string UploadFile(string FileName, string BucketName);
        string UploadFile(string FileName, byte[] data, string BucketName = "");
        HttpResult UploadStream(string FileName, Stream stream, PutExtra putExtra = null);
    }
}
