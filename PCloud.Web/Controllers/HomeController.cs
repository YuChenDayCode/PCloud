using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PCloud.Web.Models;
using MySql.Data.MySqlClient;
using PCloud.Entity.Entity;
using Framework.Data.ORM;

namespace PCloud.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int row;
            var mysql = new MysqlContainer();
            var model = new FilelistInfoEntity() { c_file_name = "aaa", FileDesc = "ccc", c_file_upload_number = 222 };
            IContainer sql = new MysqlConstructor<FilelistInfoEntity>().Update(model, new string[] { nameof(FilelistInfoEntity.c_file_name) }).where(t => t.Id == 7).Build();
            mysql.ExecuteNonQuery(sql, out row);

            //MySqlConnection conn = (MySqlConnection)new MySqlDbConnect().GetIDbConnection();
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
