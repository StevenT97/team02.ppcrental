using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.FrameWork;
using TEDU_MVC.Areas.Admin.Code;
using System.Web.Security;
using TEDU_MVC.Code;
using Models;
using System.IO;
using TEDU_MVC.DataViewModel;
using TEDU_MVC.Areas.Admin.Models;
using PagedList;

namespace TEDU_MVC.Areas.Admin.Controllers
{
    public class LoginController : BaseController
    {
        List<SelectListItem> propertytype;
        DemoPPCRentalEntities model = new DemoPPCRentalEntities();
        // GET: Admin/Login
        DemoPPCRentalEntities db = new DemoPPCRentalEntities();

        //public static int idd ;
        public void Sessionn()
        {
            //var session = (UserSession)Session[TEDU_MVC.Code.CommonConstant.USER_SESSION];
            //idd = (int)session.UserID;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session[CommonConstant.USER_SESSION] = null;
            return Redirect("/");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(LoginModels model)
        {
            //var result = new AccountModel().Login(model.UserName, model.PassWord);

            if (ModelState.IsValid)
            {
                var account = new AccountModel();
                var result = account.Login(model.UserName, MaHoa.MD5Hash(model.PassWord), true);

                if (result == 1)
                {
                    var user = account.GetID(model.UserName);
                    var userSession = new UserSession();
                    userSession.UserName = user.Email;
                    userSession.UserID = user.ID;

                    userSession.GroupID = user.GroupID;
                    var listCredentials = account.GetListCredentials(model.UserName);

                    Session.Add(CommonConstant.SESSION_CREDENTIALS, listCredentials);

                    Session.Add(CommonConstant.USER_SESSION, userSession);

                    return Redirect("/");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài Khoản Đăng Nhập Bị Khóa");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài Khoản Đăng Nhập Không Tồn Tại");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật Khẩu Đăng Nhập Không Đúng");
                }
                else if (result == -3)
                {
                    ModelState.AddModelError("", "Tai Khoan Cua Ban Khong Co Quyen Dang Nhap");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng Nhập Không Đúng");
                }
            }

            return View("Index");
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
        public JsonResult GetWard(int did)
        {
            var db = new DemoPPCRentalEntities();
            var ward = db.WARDs.Where(s => s.DISTRICT_Table.ID == did);
            return Json(ward.Select(s => new
            {
                id = s.ID,
                text = s.WardName
            }), JsonRequestBehavior.AllowGet);
        }


        [HasCredential(RoleID = "VIEW_PROPERTY_AGENCY")]
        public ActionResult ListAgency(int page = 1, int pageSize = 3)
        {
            var session = (UserSession)Session[TEDU_MVC.Code.CommonConstant.USER_SESSION];
            int idd = (int)session.UserID;
            var list = db.PROPERTies.OrderByDescending(x => x.PropertyName).Where(x => x.UserID == idd).ToList();

            return View(list);

        }

        public ActionResult Details(int id)
        {
            var pro = model.PROPERTies.Find(id);
            ViewBag.Images = Directory.EnumerateFiles(Server.MapPath("~/MultiImages"))
                             .Select(fn => "~/MultiImages/" + Path.GetFileName(fn));
            ViewBag.features = model.PROPERTY_FEATURE.Where(x => x.Property_ID == id).ToList();
            ViewBag.Countt = model.PROPERTY_FEATURE.Where(x => x.Property_ID == id).Count();
            ViewBag.fea = model.FEATUREs.ToList();

            return View(pro);
        }
        public ActionResult Create()
        {
            //PROPERTy obj = new PROPERTy();
            //obj.fEATURE = db.FEATUREs.ToList();
            //obj.GetFeatureList = db.PROPERTies.Select(x => new PROPERTy { FeatureID = x.ID, FeartureName = x.FeartureName }).ToList();

            ListAll();
            return View();
        }
        // POST: Admin/Property/Create
        [HttpPost]
        [ClearModelErrors]
        public ActionResult Create(PROPERTy property, List<HttpPostedFileBase> files, string submitP)
        {
            var session = (UserSession)Session[TEDU_MVC.Code.CommonConstant.USER_SESSION];
            int idd = (int)session.UserID;

            ListAll();

            // Create

            if (submitP == "Create")
            {
                var check = new AccountModel();
                // Validation
                // PropertyName
                if (property.PropertyName == null)
                {
                    ModelState.AddModelError("PropertyName", "PropertyName can't be empty !");
                }
                else if (property.PropertyName.Length > 100 || property.PropertyName.Length < 10)
                {
                    ModelState.AddModelError("PropertyName", "PropertyName must be between 10 and 100");
                }
                // Avatar
                if (property.ImageFile2 == null)
                {
                    ModelState.AddModelError("", "Avatar can't be empty !");
                }
                // PropertyType
                if (property.PropertyType_ID == null)
                {
                    ModelState.AddModelError("PropertyType_ID", "Avatar can't be empty !");
                }
                // Content
                if (property.Content == null)
                {
                    ModelState.AddModelError("Content", "Content can't empty !");
                }
                else if (property.Content.Length > 500 || property.Content.Length < 50)
                {
                    ModelState.AddModelError("Content", "Content must be between 50 and 500");
                }
                // Street
                if (property.Street_ID == null)
                {
                    ModelState.AddModelError("Street_ID", "Street can't be empty !");
                }
                // Ward
                if (property.Ward_ID == null)
                {
                    ModelState.AddModelError("Ward_ID", "Ward can't be empty !");
                }
                // Disetrict
                if (property.District_ID == null)
                {
                    ModelState.AddModelError("District_ID", "District can't be empty !");
                }
                // Price
                if (property.Price == null)
                {
                    ModelState.AddModelError("Price", "Price can't be empty !");
                }
                // Area
                if (property.Area == null)
                {
                    ModelState.AddModelError("Area", "Area can't be empty !");
                }
                else if (property.Area.Length > 30)
                {
                    ModelState.AddModelError("Area", "Area can't be over 30 characters");
                }
                // BedRoom
                if (property.BedRoom == null)
                {
                    ModelState.AddModelError("BedRoom", "BedRoom can't be empty !");
                }
                // BathRoom
                if (property.BathRoom == null)
                {
                    ModelState.AddModelError("BathRoom", "BathRoom can't be empty !");
                }
                // PackingPlace
                if (property.PackingPlace == null)
                {
                    ModelState.AddModelError("PackingPlace", "PackingPlace can't be empty !");
                }
                // Feature
                var featuress = Request.Form.AllKeys.Where(k => k.StartsWith("Feature_"));
                var n = featuress.Count();
                int count = 1;
                foreach (var fea in featuress)
                {
                    var ids = int.Parse(fea.Split('_')[1]);
                    if (Request.Form[fea].StartsWith("true"))
                    {
                        count += 1;

                    }


                }
                if (count == 1)
                {
                    ModelState.AddModelError("", "Feature can't be empty");

                }

                if (check.CheckPropertyName(property.PropertyName) || files[0] == null)
                {

                    if (files[0] == null)
                    {
                        ModelState.AddModelError("", "Upload File Details can't be empty");
                    }
                    if (check.CheckPropertyName(property.PropertyName))
                    {
                        ModelState.AddModelError("PropertyName", "PropertyName bị trùng");
                    }

                }
                if (files[0] != null)
                {
                    if (files.Count() > 4)
                    {
                        ModelState.AddModelError("", "Upload File Details must be between 1 and 4 Images");
                    }
                }

                try
                {

                    // Xu ly Avatar

                    string filename2 = Path.GetFileNameWithoutExtension(property.ImageFile2.FileName);
                    string extension2 = Path.GetExtension(property.ImageFile2.FileName);
                    filename2 = filename2 + DateTime.Now.ToString("yymmssfff") + extension2;
                    property.Avatar = filename2;
                    filename2 = Path.Combine(Server.MapPath("~/Avatar"), filename2);
                    property.ImageFile2.SaveAs(filename2);

                    property.Create_post = DateTime.Parse(DateTime.Now.ToShortDateString());
                    property.UserID = idd;

                    property.Images = "Done";

                    property.Status_ID = 1;

                    if (ModelState.IsValid)
                    {
                        var model = new AccountModel();
                        long id = model.InsertProperty(property);

                        var features = Request.Form.AllKeys.Where(k => k.StartsWith("Feature_"));
                        foreach (var fea in features)
                        {
                            var ids = int.Parse(fea.Split('_')[1]);
                            if (Request.Form[fea].StartsWith("true"))
                            {
                                db.PROPERTY_FEATURE.Add(new PROPERTY_FEATURE
                                {
                                    Property_ID = (int)id,
                                    Feature_ID = ids

                                });
                            }

                        }
                        db.SaveChanges();

                        // End Save Fearture
                        // SavemultiImage ----------------------------
                        var path = "";
                        foreach (var item in files)
                        {
                            if (item != null)
                            {
                                if (item.ContentLength > 0)
                                {
                                    if (Path.GetExtension(item.FileName).ToLower() == ".jpg"
                                        || Path.GetExtension(item.FileName).ToLower() == ".png"
                                        || Path.GetExtension(item.FileName).ToLower() == ".gif"
                                        || Path.GetExtension(item.FileName).ToLower() == ".jpeg")
                                    {
                                        var path0 = id + item.FileName;
                                        path = Path.Combine(Server.MapPath("~/MultiImages"), path0);

                                        item.SaveAs(path);
                                        ViewBag.UploadSuccess = true;

                                    }
                                }
                            }
                        }
                        property.Images = "Done";
                        // End SaveMultiImage -------------------------

                        if (id > 0)
                        {
                            return RedirectToAction("ListAgency", "Login");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Create Property khong thanh cong");

                        }

                    }

                }
                catch (NullReferenceException)
                {

                    property.Create_post = DateTime.Parse(DateTime.Now.ToShortDateString());

                    ListAll();
                    property.UserID = idd;
                    property.Status_ID = 1;
                    if (files[0] != null)
                    {
                        property.Images = "Done";

                    }
                    if (ModelState.IsValid)
                    {
                        var model = new AccountModel();


                        long id = model.InsertProperty(property);

                        var features = Request.Form.AllKeys.Where(k => k.StartsWith("Feature_"));
                        foreach (var fea in features)
                        {
                            var ids = int.Parse(fea.Split('_')[1]);
                            if (Request.Form[fea].StartsWith("true"))
                            {
                                db.PROPERTY_FEATURE.Add(new PROPERTY_FEATURE
                                {
                                    Property_ID = (int)id,
                                    Feature_ID = ids

                                });
                            }

                        }
                        db.SaveChanges();


                        if (id > 0)
                        {
                            return RedirectToAction("ListAgency", "Login");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Create Property khong thanh cong");

                        }

                    }
                }

            }
            // Save Draft
            else
            {
                try
                {

                    // Xu ly Avatar

                    string filename2 = Path.GetFileNameWithoutExtension(property.ImageFile2.FileName);
                    string extension2 = Path.GetExtension(property.ImageFile2.FileName);
                    filename2 = filename2 + DateTime.Now.ToString("yymmssfff") + extension2;
                    property.Avatar = filename2;
                    filename2 = Path.Combine(Server.MapPath("~/Avatar"), filename2);
                    property.ImageFile2.SaveAs(filename2);

                    property.Created_at = DateTime.Parse(DateTime.Now.ToShortDateString());
                    property.UserID = idd;

                    property.Status_ID = 2;

                    if (files[0] != null)
                    {
                        property.Images = "Done";

                    }
                    var model = new AccountModel();
                    long id = model.InsertProperty(property);

                    var features = Request.Form.AllKeys.Where(k => k.StartsWith("Feature_"));
                    foreach (var fea in features)
                    {
                        var ids = int.Parse(fea.Split('_')[1]);
                        if (Request.Form[fea].StartsWith("true"))
                        {
                            db.PROPERTY_FEATURE.Add(new PROPERTY_FEATURE
                            {
                                Property_ID = (int)id,
                                Feature_ID = ids

                            });
                        }

                    }
                    db.SaveChanges();

                    // End Save Fearture
                    // SavemultiImage ----------------------------
                    var path = "";
                    foreach (var item in files)
                    {
                        if (item != null)
                        {
                            if (item.ContentLength > 0)
                            {
                                if (Path.GetExtension(item.FileName).ToLower() == ".jpg"
                                    || Path.GetExtension(item.FileName).ToLower() == ".png"
                                    || Path.GetExtension(item.FileName).ToLower() == ".gif"
                                    || Path.GetExtension(item.FileName).ToLower() == ".jpeg")
                                {
                                    var path0 = id + item.FileName;
                                    path = Path.Combine(Server.MapPath("~/MultiImages"), path0);

                                    item.SaveAs(path);
                                    ViewBag.UploadSuccess = true;

                                }
                            }
                        }
                    }

                    // End SaveMultiImage -------------------------

                    if (id > 0)
                    {
                        return RedirectToAction("ListAgency", "Login");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Create Property khong thanh cong");

                    }



                }
                catch (NullReferenceException)
                {

                    property.Created_at = DateTime.Parse(DateTime.Now.ToShortDateString());
                    property.UserID = idd;

                    property.Status_ID = 2;
                    if (files[0] != null)
                    {
                        property.Images = "Done";

                    }

                    var model = new AccountModel();
                    long id = model.InsertProperty(property);

                    var features = Request.Form.AllKeys.Where(k => k.StartsWith("Feature_"));
                    foreach (var fea in features)
                    {
                        var ids = int.Parse(fea.Split('_')[1]);
                        if (Request.Form[fea].StartsWith("true"))
                        {
                            db.PROPERTY_FEATURE.Add(new PROPERTY_FEATURE
                            {
                                Property_ID = (int)id,
                                Feature_ID = ids

                            });
                        }

                    }
                    db.SaveChanges();
                    // SavemultiImage ----------------------------
                    var path = "";
                    foreach (var item in files)
                    {
                        if (item != null)
                        {
                            if (item.ContentLength > 0)
                            {
                                if (Path.GetExtension(item.FileName).ToLower() == ".jpg"
                                    || Path.GetExtension(item.FileName).ToLower() == ".png"
                                    || Path.GetExtension(item.FileName).ToLower() == ".gif"
                                    || Path.GetExtension(item.FileName).ToLower() == ".jpeg")
                                {
                                    var path0 = id + item.FileName;
                                    path = Path.Combine(Server.MapPath("~/MultiImages"), path0);

                                    item.SaveAs(path);
                                    ViewBag.UploadSuccess = true;

                                }
                            }
                        }
                    }

                    // EndmultiImage ----------------------------

                    if (id > 0)
                    {
                        return RedirectToAction("ListAgency", "Login");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Create Property khong thanh cong");

                    }

                }
            }

            return View();
        }
        public void ListAll()
        {

            ViewBag.property_type = model.PROPERTY_TYPE.ToList();
            ViewBag.feature = model.FEATUREs.ToList();
            ViewBag.street = model.STREETs.OrderBy(x => x.StreetName).ToList();
            ViewBag.ward = model.WARDs.OrderBy(x => x.WardName).ToList();
            ViewBag.district = model.DISTRICT_Table.OrderBy(x => x.DistrictName).ToList();
            ViewBag.user = model.USERs.OrderBy(x => x.FullName).ToList();
            ViewBag.status = model.PROJECT_STATUS.OrderBy(x => x.Status_Name).ToList();

        }



    }
}