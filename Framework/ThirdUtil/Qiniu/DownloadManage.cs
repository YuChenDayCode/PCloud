using Qiniu.Storage;
using Qiniu.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Myn.ThirdUtil.Qiniu
{
    public class DownloadManage : QiniuConfig
    {
        /// <summary>
        /// 获得私有下载地址
        /// </summary>
        public string CreatePrivateUrl(string key, string domain = "")
        {
            if (string.IsNullOrWhiteSpace(domain)) domain = this.Domain;
            Mac mac = new Mac(AccessKey, SecretKey);
            string privateUrl = DownloadManager.CreatePrivateUrl(mac, domain, key, 3600);
            return privateUrl;
        }
        public string CreatePrivateUrl(string key, int expireInSeconds, string domain = "")
        {
            if (string.IsNullOrWhiteSpace(domain)) domain = this.Domain;
            Mac mac = new Mac(AccessKey, SecretKey);
            string privateUrl = DownloadManager.CreatePrivateUrl(mac, domain, key, expireInSeconds);
            return privateUrl;
        }
        /// <summary>
        /// 私有bucket无法创建公开链接
        /// </summary>
        /// <param name="key"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public string CreatePublishUrl(string key, string domain = "")
        {
            if (string.IsNullOrWhiteSpace(domain)) domain = this.Domain;
            string publicUrl = DownloadManager.CreatePublishUrl(domain, key);
            return publicUrl;
        }
    }
}
