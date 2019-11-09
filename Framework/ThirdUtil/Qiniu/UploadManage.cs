//using Qiniu.Storage;
//using Qiniu.Util;
using Qiniu.Http;
using Qiniu.Storage;
using Qiniu.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Myn.ThirdUtil.Qiniu
{
    public class UploadManage : QiniuConfig
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="FileName">文件path</param>
        /// <param name="BucketName">bucket</param>
        /// <param name="Expires">有效期(秒)</param>
        /// <returns></returns>
        public string UploadFile(string FileName, string BucketName = "")
        {
            if (string.IsNullOrWhiteSpace(BucketName)) BucketName = this.Bucket;
            System.IO.FileInfo file = new System.IO.FileInfo(FileName);

            string key = file.Name;
            Mac mac = new Mac(AccessKey, SecretKey);
            PutPolicy pp = new PutPolicy();//上传参数
            pp.Scope = $"{BucketName}:{key}";
            pp.SetExpires(3600);
            //pp.DeleteAfterDays = 1;
            string Token = Auth.CreateUploadToken(mac, pp.ToJsonString());
            Config config = new Config()
            {
                Zone = Zone.ZONE_CN_East,
            };
            FormUploader upload = new FormUploader(config);
            HttpResult result = upload.UploadFile(FileName, key, Token, null);
            return result.ToString();

        }
        public string UploadFile(string FileName, string BucketName = "", int Expires = 3600)
        {
            if (string.IsNullOrWhiteSpace(BucketName)) BucketName = this.Bucket;
            System.IO.FileInfo file = new System.IO.FileInfo(FileName);

            string key = file.Name;
            Mac mac = new Mac(AccessKey, SecretKey);
            PutPolicy pp = new PutPolicy();//上传参数
            pp.Scope = $"{BucketName}:{key}"; //如果云端已有同名文件则覆盖，使用 SCOPE = "BUCKET:KEY"
            pp.SetExpires(Expires);
            //pp.DeleteAfterDays = 1;
            string Token = Auth.CreateUploadToken(mac, pp.ToJsonString());
            Config config = new Config()
            {
                Zone = Zone.ZONE_CN_East,
            };
            FormUploader upload = new FormUploader(config);
            HttpResult result = upload.UploadFile(FileName, key, Token, null);
            //result.
            return result.ToString();

        }
    }
}
