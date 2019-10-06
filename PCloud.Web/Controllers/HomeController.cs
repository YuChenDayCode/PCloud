using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PCloud.Web.Models;
using MySql.Data.MySqlClient;
using PCloud.Entity.Entity;
using Myn.Data.ORM;

namespace PCloud.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int row;

            IDbProvider<FilelistInfoEntity> db = new MysqlProvider<FilelistInfoEntity>();
            var a = db.Get(t => t.Id == 6);

            List<FilelistInfoEntity> list = new List<FilelistInfoEntity>();
            for (int i = 0; i < 5; i++)
            {

            }
            var model = new FilelistInfoEntity()
            {
                c_file_name = "Everything",
                FileDesc = "查找文件快得一批啊",
                c_file_upload_number = 210,
                c_file_isdel = false,
                c_file_create_time = DateTime.Now,
                c_file_upload_time = DateTime.Now
            };
            list.Add(model);
            int id;
            db.Insert_Return_Id(model, out id);

            /*
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


            return View();
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
