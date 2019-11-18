using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PCloud.Web.Controllers
{
    public class FileOperateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FileUpload()
        {
            return View();
        }
    }
}