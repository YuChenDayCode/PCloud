using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Myn.Data.ORM;
using Myn.ThirdUtil.Qiniu;
using Newtonsoft.Json.Linq;
using PCloud.Entity.Entity;
using Qiniu.Http;
using Qiniu.Storage;

namespace PCloud.Web.Controllers
{
    public class FileOperateController : Controller
    {
        private IQiniu qiniu;
        IDbProvider<OssFile> ossfile;
        public FileOperateController(IQiniu _qiniu, IDbProvider<OssFile> _dbProvider)
        {
            qiniu = _qiniu;
            ossfile = _dbProvider;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UploadView()
        {
            return View();
        }

        [RequestSizeLimit(209715200)]
        public void FileUpload()
        {
            try
            {
                int fileid = 0;
                var files = Request.Form.Files;
                if (files.Count > 0)
                {
                    var file = files.First();
                    if (file.Length > (200 * 1024 * 1024))
                    {
                        //return Json("文件过大，不能大于200M");
                    }
                    PutExtra putExtra = new PutExtra();// { ProgressHandler = UploadProgressHandler,  ResumeRecordFile  };
                    putExtra.ProgressHandler = UploadProgressHandler;
                    putExtra.UploadController = DefaultUploadController;
                    putExtra.ResumeRecordFile = ResumeHelper.GetDefaultRecordKey($"{Environment.CurrentDirectory}\\{file.FileName}", file.FileName);
                    var aa = putExtra.ResumeRecordFile;
                    putExtra.ResumeRecordFile = file.FileName + ".progress";
                    HttpResult result = new HttpResult();
                    Stream stream = file.OpenReadStream();
                    result = qiniu.UploadStream(file.FileName, stream, putExtra);
                    if (result.Code == (int)HttpCode.OK)
                    {
                        //todo 入库文件信息
                        var rj = JObject.Parse(result.Text);
                        string hash = rj["hash"].ToString();
                        string key = rj["key"].ToString();
                        var hashentity = ossfile.GetList(t => t.FileHash == hash);
                        OssFile ossFileEntity = new OssFile
                        {
                            FileKey = key,
                            FileHash = hash,
                            FileDomain = ""
                        };
                        ossfile.Insert_Return_Id(ossFileEntity, out fileid);
                    }
                    //检查删除文件
                    if (System.IO.File.Exists($"{Environment.CurrentDirectory}\\{file.FileName}"))
                    {
                        System.IO.File.Delete($"{Environment.CurrentDirectory}\\{file.FileName}");
                    }
                    //using (StreamWriter sw = new StreamWriter(Response.Body))
                    //{
                    //    sw.Write(fileid);
                    //}
                    //return Json(result.ToString());
                }
                //return null;
            }
            catch (Exception ex)
            {
                // return Json(ex.Message);
            }

        }

        public void UploadProgressHandler(long loadbytes, long totalbytes)
        {
            try
            {
                string ppp = (100.0 * loadbytes / totalbytes).ToString("F2") + "%";
                if (loadbytes < totalbytes)
                {
                    Console.WriteLine("[{0}] [FormUpload] Progress: {1,7:0.000}%", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff"), 100.0 * loadbytes / totalbytes);
                }
                else
                {
                    Console.WriteLine("[{0}] [FormUpload] Progress: {1,7:0.000}%\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff"), 100.0);
                }
                if (!Response.HasStarted)
                {
                    if (!Response.Headers.ContainsKey("Connection"))
                        Response.Headers.Add("Connection", "keep-alive");
                    if (!Response.Headers.ContainsKey("Content-Encoding"))
                        Response.Headers.Add("Content-Encoding", "UTF-8");

                    Response.ContentType = "text/html";
                }
                
                //Response.Body = new StreamReader()
                Response.Body.Write(System.Text.Encoding.UTF8.GetBytes(ppp));
                //Response.Body.Flush();
                //Response.Body.Close();
                //Response.Body.Dispose();
                

            }
            catch (Exception ex)
            {
            }
        }
        public static UploadControllerAction DefaultUploadController()
        {
            return UploadControllerAction.Activated;
        }

    }
}