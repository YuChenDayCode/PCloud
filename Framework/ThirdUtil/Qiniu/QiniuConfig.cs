using Myn.Core.AppSettingManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Myn.ThirdUtil.Qiniu
{
    /// <summary>
    /// 七牛云基本配置
    /// </summary>
    public class QiniuConfig
    {
        /// <summary>
        /// key
        /// </summary>
        public string AccessKey;
        /// <summary>
        /// skey
        /// </summary>
        public string SecretKey;
        /// <summary>
        /// Bucket 空间名
        /// </summary>
        public string Bucket;

        public string Domain;
        public string LocalFile;
        public QiniuConfig()
        {
            //可以将参数配置文件化
            bool Enable = Convert.ToBoolean(AppSettingConfig.GetAppSetting()["AppSetting:Qiniu:Enable"]);
            if (Enable)
            {
                this.AccessKey = AppSettingConfig.GetAppSetting()["AppSetting:Qiniu:AccessKey"];
                this.SecretKey = AppSettingConfig.GetAppSetting()["AppSetting:Qiniu:SecretKey"];
                this.Bucket = AppSettingConfig.GetAppSetting()["AppSetting:Qiniu:Bucket"];
                this.Domain = AppSettingConfig.GetAppSetting()["AppSetting:Qiniu:Domain"];
            }
        }
    }
}
