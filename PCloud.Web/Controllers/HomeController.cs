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
            var a = db.GetListPage(t => t.Id > 10, 1, 19, out row, t => t.c_file_name, "DESC",t=>t.c_file_create_time);


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

            /*
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
