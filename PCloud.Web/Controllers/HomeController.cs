﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PCloud.Web.Models;
using MySql.Data.MySqlClient;
using PCloud.Entity.Entity;
using Myn.Data.ORM;
using Myn.ThirdUtil.Qiniu;
using System.IO;

namespace PCloud.Web.Controllers
{
    public class HomeController : Controller
    {
        private IQiniu qiniu;
        private IDbProvider<FilelistInfoEntity> dbProvider;

        public HomeController(IQiniu _qiniu, IDbProvider<FilelistInfoEntity> _dbProvider)
        {
            qiniu = _qiniu;
            dbProvider = _dbProvider;
        }
        public IActionResult Index()
        {

            #region qiniu
            /* string file = "D:\\geek.exe";
             // var aa = qiniu.UploadFile(file, "yuchen-space");
             //string r = qiniu.CreatePrivateUrl("geek.exe"); */
            #endregion

            /*IDbProvider<Test1Entity> db = new SqlServerProvider<Test1Entity>();
            List<Test1Entity> list = new List<Test1Entity>();
            for (int i = 0; i < 5; i++)
            {
                list.Add(new Test1Entity { test = i + " bbb"});
            }

            int ri = db.Insert(list);
            var aa = db.All();*/
            #region orm test
            /*           IDbProvider<FilelistInfoEntity> db = new MysqlProvider<FilelistInfoEntity>();
                       var model = new FilelistInfoEntity()
                       {

                           c_file_name = "Everything11111111",
                           FileDesc = "查找文件快得一批啊啊啊啊啊",
                           c_file_upload_number = 210,
                           c_file_isdel = false,
                           c_file_create_time = DateTime.Now,
                          // c_file_upload_time = DateTime.Now,
                       };
                       var b = dbProvider.Insert(model);
                       int row;
                         // IDbProvider<FilelistInfoEntity> db = new MysqlProvider<FilelistInfoEntity>();
                          var a = dbProvider.GetListPage(t => t.Id > 10, 1, 19, out row, t => t.c_file_name, "DESC");

                           var a = db.GetListPage(t => t.Id > 10, 1, 19, out row, t => t.c_file_name, "DESC", t => t.c_file_create_time,"ASC");

                                       List<FilelistInfoEntity> list = new List<FilelistInfoEntity>();
                                       var model = new FilelistInfoEntity()
                                       {

                                           c_file_name = "Everything11111111",
                                           FileDesc = "查找文件快得一批啊啊啊啊啊",
                                           c_file_upload_number = 210,
                                           c_file_isdel = false,
                                           c_file_create_time = DateTime.Now,
                                           c_file_upload_time = DateTime.Now
                                       };
                                       list.Add(model);


                                       // int rd = db.Delete(new int[] { 17, 18 });
                                       //var aa = db.Update(model,t => t.Id == 10,new[] { nameof(FilelistInfoEntity.FileDesc) });
                                       //var a = db.GetList(t=>t.FileDesc.Contains("%c%"));
                                       // var a = db.Count(t => t.Id >= 19);


                                       int id;
                                       db.Insert_Return_Id(model, out id);


                                       MysqlQuery<FilelistInfoEntity> query = new MysqlQuery<FilelistInfoEntity>();
                                       ISqlDocker docker = query.Count().where(t => t.Id == 6).Build();
                                       var model = new FilelistInfoEntity()
                                       {
                                           c_file_name = "cesa",
                                           FileDesc = "info",
                                           c_file_upload_number = 111,
                                           c_file_isdel = true,
                                           c_file_create_time = DateTime.Now,
                                           c_file_upload_time = DateTime.Now
                                       };

                                       ISqlDocker sql =  new MysqlConstructor<FilelistInfoEntity>().Insert(model).Build();
                                       mysql.ExecuteNonQuery(sql, out row);
                                       */

            #endregion
            return View();

        }

        public ActionResult GetUrl()
        {
            DownloadManage dm = new DownloadManage();
            string r1 = dm.CreatePrivateUrl("Git-2.22.0-64-bit.exe", "q3ik67k15.bkt.clouddn.com");
            return Json(r1);
        }

        public IActionResult Test()
        {
            return View();
        }
        public void Tttt()
        {

            using (StreamWriter wr = new StreamWriter(Response.Body))
            {
                Response.ContentType = "text/html;charset=UTF-8";
                wr.WriteLine("111111");
                wr.WriteLine("中文");
            }
        }

        [EntityMapper_TableName("tree")]
        public class Entity
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Pid { get; set; }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
