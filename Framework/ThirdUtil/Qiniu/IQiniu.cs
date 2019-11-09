using System;
using System.Collections.Generic;
using System.Text;

namespace Myn.ThirdUtil.Qiniu
{
    public interface IQiniu
    {
        string UploadFile(string FileName, string BucketName);
        string CreatePrivateUrl(string FileName, string Domain="");
    }
}
