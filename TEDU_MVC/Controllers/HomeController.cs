using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Models.FrameWork;
using System.IO;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using LinqKit;

namespace TEDU_MVC.Controllers
{
    public class HomeController : Controller
    {
        List<SelectListItem> myList, myList2, propertytype, street;
        DemoPPCRentalEntities db = new DemoPPCRentalEntities();
        // GET: Home
        public ActionResult Index(int page = 1, int pageSize = 11)
        {
            ListAll();
            var propertymodel = new AccountModel();
            var model = propertymodel.ListAllPagingHome(page, pageSize);
            return View(model);
        }
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuModel().ListByGroupId(1);
            return PartialView(model);
        }
        public ActionResult Details(int id)
        {
            var pro = db.PROPERTies.Find(id);
            ViewBag.Images = Directory.EnumerateFiles(Server.MapPath("~/MultiImages"))
                             .Select(fn => "~/MultiImages/" + Path.GetFileName(fn));
            ViewBag.features = db.PROPERTY_FEATURE.Where(x => x.Property_ID == id).ToList();
            ViewBag.Countt = db.PROPERTY_FEATURE.Where(x => x.Property_ID == id).Count();
            ViewBag.fea = db.FEATUREs.ToList();
            return View(pro);
        }
        public JsonResult GetStreet(int did)
        {
            var db = new DemoPPCRentalEntities();
            var streets = db.STREETs.Where(s => s.DISTRICT_Table.ID == did);
            return Json(streets.Select(s => new
            {
                id = s.ID,
                text = s.StreetName
            }), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Send(string name, string mobile, string email, string content)
        {
            var feedback = new Contact();
            feedback.Name = name;
            feedback.Email = email;
            feedback.CreateDatetime = DateTime.Now;
            feedback.Phone = mobile;
            feedback.Content = content;

            var id = new ContactModel().InsertFeedBack(feedback);
            if (id > 0)
            {
                return Json(new
                {
                    status = true
                });
                //send mail
            }

            else
                return Json(new
                {
                    status = false
                });

        }

        [HttpGet]
        public ActionResult Search(string text, int? Quan, int? Type, string minPrice, string maxPrice)
        {

            var pro = db.PROPERTies.Where(x => x.Status_ID == 3);

            ListAll();

            if (!(String.IsNullOrEmpty(text)) || !(String.IsNullOrWhiteSpace(text)))
            {
                pro = pro.Where(x => x.PropertyName.Contains(text));
            }
            try
            {
                if (minPrice != null || !(String.IsNullOrEmpty(minPrice)) || !(String.IsNullOrWhiteSpace(minPrice)) ||!(minPrice.Equals("")))
                {
                    int PriceMin = int.Parse(minPrice);
                    pro = pro.Where(x => x.Price > PriceMin);
                }
            }
            catch (FormatException)
            {

            }
            try
            {
                if (maxPrice != null || !(String.IsNullOrEmpty(maxPrice)) || !(String.IsNullOrWhiteSpace(maxPrice)) || !(maxPrice.Equals("")))
                {
                    int PriceMax = int.Parse(maxPrice);
                    pro = pro.Where(x => x.Price < PriceMax);
                }
            }
            catch (FormatException)
            {

            }

            //if (Duong != null)
            //{
            //    pro = pro.Where(x => x.Street_ID == Duong);
            //}
            if (Quan != null)
            {
                pro = pro.Where(x => x.District_ID == Quan);
            }
            if (Type != null)
            {
                pro = pro.Where(x => x.PropertyType_ID == Type);
            }

            return View(pro.ToList());

        }

        //public ActionResult Search2(string text, string Quan, string Type)
        //{
        //    var terms = text?.Split(' ') ?? new string[0];
        //    var predicate = terms.Aggregate(
        //        PredicateBuilder.New<PROPERTy>(string.IsNullOrEmpty(text)),
        //        (acc, term) => acc.Or(b => b.PropertyName.Contains(term)));

        //    var predicateQuan = Quan.Aggregate(
        //          PredicateBuilder.New<PROPERTy>(string.IsNullOrEmpty(Quan)),
        //        (acc, term) => acc.Or(b => b.DISTRICT_Table.DistrictName.Contains(Quan)));

        //    var predicateType = Type.Aggregate(
        //          PredicateBuilder.New<PROPERTy>(string.IsNullOrEmpty(Type)),
        //        (acc, term) => acc.Or(b => b.PROPERTY_TYPE.CodeType.Contains(Type)));

        //    var propertys = db.PROPERTies.AsExpandable()
        //                        .Where(predicate)
        //                        .Where(predicateQuan)
        //                        .Where(predicateType)
        //                        .OrderBy(b => b.PropertyName)
        //                        .ToArray();

        //    return View(propertys);
        //}

        public void ListAll()
        {
            myList = new List<SelectListItem>();
            myList2 = new List<SelectListItem>();
            propertytype = new List<SelectListItem>();
            street = new List<SelectListItem>();
            var distr = db.DISTRICT_Table.Where(x => x.ID >= 31 && x.ID <= 54);
            var str = db.STREETs.ToList();
            var ward1 = db.WARDs.ToList().OrderBy(x => x.WardName);
            var protype = db.PROPERTY_TYPE.ToList().OrderBy(x => x.CodeType);

            //myList.Add(new SelectListItem { Text = "ALL", Value = "ALL" });
            //myList2.Add(new SelectListItem { Text = "ALL", Value = "ALL" });
            //propertytype.Add(new SelectListItem { Text = "ALL", Value = "ALL" });

            ////////
            foreach (var x in distr)
            {
                myList.Add(new SelectListItem { Text = x.DistrictName, Value = x.DistrictName });
            }
            ViewData["data1"] = myList;
            /////
            foreach (var x in ward1)
            {
                myList2.Add(new SelectListItem { Text = x.WardName, Value = x.WardName });
            }
            ViewData["data2"] = myList2;
            //////
            foreach (var x in protype)
            {
                propertytype.Add(new SelectListItem { Text = x.CodeType, Value = x.CodeType });
            }
            ViewData["data3"] = propertytype;

            foreach (var x in str)
            {
                street.Add(new SelectListItem { Text = x.StreetName, Value = x.StreetName });
            }
            ViewData["data4"] = street;
        }
    }
}