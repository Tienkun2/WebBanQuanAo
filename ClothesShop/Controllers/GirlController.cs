using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesShop.Controllers
{
    public class GirlController : Controller
    {
        // GET: Girl
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NewProd()
        {
            return View();
        }
    }
}