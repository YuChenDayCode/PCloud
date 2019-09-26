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
            var model = new FilelistInfoEntity() { Id = 2, c_file_name = "admin2", c_file_name1 = "filetype", c_file_name2 = "11", c_file_name3 = "22", c_file_name4 = "33",  FileDesc = "123123123", c_file_upload_number = 123123 };
            IContainer sql = new MysqlConstructor<FilelistInfoEntity>().Insert(model).Build();
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
