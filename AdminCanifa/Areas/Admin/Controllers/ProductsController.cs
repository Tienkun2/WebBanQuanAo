using AdminCanifa.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace AdminCanifa.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Admin/Products
        public ActionResult Index()
        {
            CanifaEntities1 db = new CanifaEntities1();
            List<Cloth> clos = db.Clothes.ToList();

            return View(clos);
        }


        public ActionResult Add()
        {
            using (CanifaEntities1 db = new CanifaEntities1())
            {
                var categories = db.Categories.Select(c => new SelectListItem
                {
                    Value = c.CategoryID.ToString(),
                    Text = c.CategoryName
                }).ToList();
                ViewBag.Categories = categories;

                var clothingTypes = db.ClothingTypes.Select(c => new SelectListItem
                {
                    Value = c.ClothingTypeID.ToString(),
                    Text = c.ClothingTypeName
                }).ToList();
                ViewBag.ClothingTypes = clothingTypes;

                // Đặt ClothingStyles rỗng ban đầu
                ViewBag.ClothingStyles = new List<SelectListItem>();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Add(Cloth cloth)
        {
            if (ModelState.IsValid)
            {
                using (CanifaEntities1 db = new CanifaEntities1())
                {
                    cloth.ClothesID = "CTL000";
                    db.Clothes.Add(cloth);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(cloth);
        }

        //    public JsonResult GetClothingTypes(string clothID) 
        //    {
        //        using (CanifaEntities1 db = new CanifaEntities1())
        //        {
        //            var clothingTypes = db.ClothingTypes
        //                .Where(ct => ct.ClothingTypeID == clothID)
        //                .Select(ct => new
        //                {
        //                    ct.ClothingTypeID,
        //                    ct.ClothingTypeName
        //                }).ToList();

        //            return Json(clothingTypes, JsonRequestBehavior.AllowGet);
        //        }
        //    }

        //    public JsonResult GetClothingStyles(string clothingTypeId)
        //    {
        //        using (CanifaEntities1 db = new CanifaEntities1())
        //        {
        //            var clothingStyles = db.ClothingStyles
        //                .Where(cs => cs.ClothingTypeID == clothingTypeId)
        //                .Select(cs => new
        //                {
        //                    cs.ClothingStyleID,
        //                    cs.ClothingStyleName
        //                }).ToList();

        //            return Json(clothingStyles, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //}
    }
}
