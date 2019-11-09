using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Data_Vizualizer.Controllers
{
    public class DataTypeDeciderController : Controller
    {
        // GET: DataTypeDecider
        public ActionResult DataTypeDecider()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DataTypeDecider(string data)
        {

            
            ViewBag.data = data;
            
            return View();
        }
    }
}