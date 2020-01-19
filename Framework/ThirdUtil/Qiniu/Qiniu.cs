
using Qiniu.Http;
using Qiniu.Storage;
using Qiniu.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Myn.ThirdUtil.Qiniu
{
    public class Qiniu : QiniuConfig, IQiniu
    {
        public string UploadFile(string FileName, string BucketName)
        {
            UploadManage um = new UploadManage();
            return um.UploadFile(FileName, BucketName);
        }
        public string UploadFile(string FileName, byte[] data, string BucketName)
        {
            UploadManage um = new UploadManage();
            return um.UploadFile(FileName, data);
        }

        public HttpResult UploadStream(string FileName, Stream stream, PutExtra putExtra)
        {
            Mac mac = new Mac(AccessKey, SecretKey);
            PutPolicy pp = new PutPolicy();//上传参数
            pp.Scope = $"{this.Bucket}:{FileName}";
            pp.SetExpires(3600);
            //pp.DeleteAfterDays = 1;
            string Token = Auth.CreateUploadToken(mac, pp.ToJsonString());
            Config config = new Config()
            {
                Zone = Zone.ZONE_CN_East,
                UseHttps = true,
                UseCdnDomains = true,
                ChunkSize = ChunkUnit.U1024K
            };
           // FormUploader upload = new FormUploader(config);
            ResumableUploader resumableUploader = new ResumableUploader(config);


            HttpResult result = resumableUploader.UploadStream(stream, FileName, Token, putExtra);
            return result;
        }

        public string CreatePrivateUrl(string FileName, string Domain)
        {
            DownloadManage dm = new DownloadManage();
            return dm.CreatePrivateUrl(FileName, Domain);
        }

    }

}


