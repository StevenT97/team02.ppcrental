using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Models.FrameWork;
using System.IO;
using TEDU_MVC.Code;
using TEDU_MVC.Areas.Admin.Code;
using TEDU_MVC.Areas.Admin.Models;

namespace TEDU_MVC.Areas.Admin.Controllers
{
    public class PropertyController : BaseController
    {

        // GET: Admin/Property
        List<SelectListItem> propertytype;
        DemoPPCRentalEntities models = new DemoPPCRentalEntities();
        [HasCredential(RoleID = "VIEW_PROPERTY")]
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var propertymodel = new AccountModel();
            var model = propertymodel.ListAllPaging(page, pageSize);
            return View(model);


        }
        public ActionResult ViewListProperty(int id)
        {
            var pro = models.PROPERTies.Where(x => x.UserID == id).ToList();
            return View(pro);
        }


        [HttpPost]

        public ActionResult Upload(List<HttpPostedFileBase> files)
        {
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
                            path = Path.Combine(Server.MapPath("~/MultiImages/"), item.FileName);
                            item.SaveAs(path);
                            path.Clone();
                            //ViewBag.UploadSuccess = true;

                        }
                    }
                }
            }
            return View();
        }
        // GET: Admin/Property/Details/5
        public ActionResult Details(int id)
        {
            var pro = models.PROPERTies.Find(id);
            ViewBag.Images = Directory.EnumerateFiles(Server.MapPath("~/MultiImages"))
                             .Select(fn => "~/MultiImages/" + Path.GetFileName(fn));
            ViewBag.features = models.PROPERTY_FEATURE.Where(x => x.Property_ID == id).ToList();
            ViewBag.Countt = models.PROPERTY_FEATURE.Where(x => x.Property_ID == id).Count();
            ViewBag.fea = models.FEATUREs.ToList();
            return View(pro);
        }

        // GET: Admin/Property/Create
        public ActionResult Create()
        {

            ListAll();
            return View();
        }

        // POST: Admin/Property/Create
        [HttpPost]
        public ActionResult Create(PROPERTy property, List<HttpPostedFileBase> files)
        {
            ListAll();

            try
            {

                // Xu ly Avatar

                string filename2 = Path.GetFileNameWithoutExtension(property.ImageFile2.FileName);
                string extension2 = Path.GetExtension(property.ImageFile2.FileName);
                filename2 = filename2 + DateTime.Now.ToString("yymmssfff") + extension2;
                property.Avatar = filename2;
                filename2 = Path.Combine(Server.MapPath("~/Avatar"), filename2);
                property.ImageFile2.SaveAs(filename2);



                //// Images

                //string filename = Path.GetFileNameWithoutExtension(property.ImageFile.FileName);
                //string extension = Path.GetExtension(property.ImageFile.FileName);
                //filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                //property.Images = filename;
                //filename = Path.Combine(Server.MapPath("~/Images"), filename);
                //property.ImageFile.SaveAs(filename);





                property.Created_at = DateTime.Parse(DateTime.Now.ToShortDateString());

                if (ModelState.IsValid)
                {
                    var model = new AccountModel();
                    long id = model.InsertProperty(property);

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
                        else
                        {
                            break;
                        }
                    }
                    // End SaveMultiImage -------------------------

                    if (id > 0)
                    {
                        return RedirectToAction("Index", "Property");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Create Property khong thanh cong");

                    }

                }

            }
            catch (NullReferenceException)
            {

                property.Created_at = DateTime.Parse(DateTime.Now.ToShortDateString());

                ListAll();

                if (ModelState.IsValid)
                {
                    var model = new AccountModel();
                    long id = model.InsertProperty(property);
                    if (id > 0)
                    {
                        return RedirectToAction("Index", "Property");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Create Property khong thanh cong");

                    }

                }
            }


            return View();
        }

        // GET: Admin/Property/Edit/5
        public ActionResult Edit(int id)
        {
            var property = new AccountModel().ViewDetail(id);
            ListAll();

            return View(property);
        }

        // POST: Admin/Property/Edit/5
        [HttpPost]
        [ClearModelErrors]
        public ActionResult Edit(PROPERTy property, List<HttpPostedFileBase> files, string editP)
        {
            ListAll();
            var session = (UserSession)Session[TEDU_MVC.Code.CommonConstant.USER_SESSION];
            int idd = (int)session.UserID;
            if (session.GroupID == "SALE")
            {
                property.Sale_ID = (int)session.UserID;
            }
            if (editP == "Save Post")
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
                var propertys = models.PROPERTies.Find(property.ID);
                if (propertys.Avatar == null && property.ImageFile2 == null)
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

                if (propertys.Images == null && files[0] == null)
                {
                    ModelState.AddModelError("", "Upload File Details can't be empty");
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
                    if (files[0] != null)
                    {
                        ViewBag.Images = Directory.EnumerateFiles(Server.MapPath("~/MultiImages"))
                          .Select(fn => "~/MultiImages/" + Path.GetFileName(fn));
                        foreach (var image in (IEnumerable<string>)ViewBag.Images)
                        {

                            if (image.Contains(property.ID.ToString()))
                            {

                                System.IO.File.Delete(Server.MapPath(image));

                            }


                        }
                    }
                }
                catch (Exception exx)
                {

                }
                try
                {
                    property.Status_ID = 1;
                   
                    // Xu ly MultiImage
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
                                    var path0 = property.ID + item.FileName;
                                    path = Path.Combine(Server.MapPath("~/MultiImages"), path0);

                                    item.SaveAs(path);
                                    ViewBag.UploadSuccess = true;

                                }
                            }
                        }
                    }

                    //// Xu ly Avatar

                    string filename2 = Path.GetFileNameWithoutExtension(property.ImageFile2.FileName);
                    string extension2 = Path.GetExtension(property.ImageFile2.FileName);
                    filename2 = filename2 + DateTime.Now.ToString("yymmssfff") + extension2;
                    property.Avatar = filename2;
                    filename2 = Path.Combine(Server.MapPath("~/Avatar"), filename2);
                    property.ImageFile2.SaveAs(filename2);
                   
                    if (ModelState.IsValid)
                    {
                        property.Images = "Done";
                        var model = new AccountModel();
                        var res = model.Update(property);

                        models.PROPERTY_FEATURE.RemoveRange(models.PROPERTY_FEATURE.Where(x => x.Property_ID == property.ID));
                        var features = Request.Form.AllKeys.Where(k => k.StartsWith("Feature_"));
                        foreach (var fea in features)
                        {
                            var ids = int.Parse(fea.Split('_')[1]);
                            if (Request.Form[fea].StartsWith("true"))
                            {
                                models.PROPERTY_FEATURE.Add(new PROPERTY_FEATURE
                                {
                                    Property_ID = property.ID,
                                    Feature_ID = ids

                                });
                            }

                        }
                        models.SaveChanges();

                        if (res)
                        {
                            return RedirectToAction("ListAgency", "Login");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Update không thành công");
                        }
                    }

                }
                catch
                {
                    if (ModelState.IsValid)
                    {
                        property.Images = "Done";
                        var model = new AccountModel();
                        var res = model.Update(property);

                        models.PROPERTY_FEATURE.RemoveRange(models.PROPERTY_FEATURE.Where(x => x.Property_ID == property.ID));
                        var features = Request.Form.AllKeys.Where(k => k.StartsWith("Feature_"));
                        foreach (var fea in features)
                        {
                            var ids = int.Parse(fea.Split('_')[1]);
                            if (Request.Form[fea].StartsWith("true"))
                            {
                                models.PROPERTY_FEATURE.Add(new PROPERTY_FEATURE
                                {
                                    Property_ID = property.ID,
                                    Feature_ID = ids

                                });
                            }

                        }
                        models.SaveChanges();

                        if (res)
                        {
                            return RedirectToAction("ListAgency", "Login");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Update không thành công");
                        }
                    }
                }

            }
            // Save Edit Draft---------------------------------------------------------------------------
            else
            {
                try
                {
                    if (files[0] != null)
                    {
                        ViewBag.Images = Directory.EnumerateFiles(Server.MapPath("~/MultiImages"))
                          .Select(fn => "~/MultiImages/" + Path.GetFileName(fn));
                        foreach (var image in (IEnumerable<string>)ViewBag.Images)
                        {

                            if (image.Contains(property.ID.ToString()))
                            {

                                System.IO.File.Delete(Server.MapPath(image));

                            }


                        }
                    }
                }
                catch (Exception exx)
                {

                }
                try
                {

                    // Xu ly MultiImage
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
                                    var path0 = property.ID + item.FileName;
                                    path = Path.Combine(Server.MapPath("~/MultiImages"), path0);

                                    item.SaveAs(path);
                                    ViewBag.UploadSuccess = true;

                                }
                            }
                        }
                    }

                    //// Xu ly Avatar

                    string filename2 = Path.GetFileNameWithoutExtension(property.ImageFile2.FileName);
                    string extension2 = Path.GetExtension(property.ImageFile2.FileName);
                    filename2 = filename2 + DateTime.Now.ToString("yymmssfff") + extension2;
                    property.Avatar = filename2;
                    filename2 = Path.Combine(Server.MapPath("~/Avatar"), filename2);
                    property.ImageFile2.SaveAs(filename2);

                    if (ModelState.IsValid)
                    {
                        var model = new AccountModel();
                        var res = model.Update(property);

                        models.PROPERTY_FEATURE.RemoveRange(models.PROPERTY_FEATURE.Where(x => x.Property_ID == property.ID));
                        var features = Request.Form.AllKeys.Where(k => k.StartsWith("Feature_"));
                        foreach (var fea in features)
                        {
                            var ids = int.Parse(fea.Split('_')[1]);
                            if (Request.Form[fea].StartsWith("true"))
                            {
                                models.PROPERTY_FEATURE.Add(new PROPERTY_FEATURE
                                {
                                    Property_ID = property.ID,
                                    Feature_ID = ids

                                });
                            }

                        }
                        models.SaveChanges();

                        if (res)
                        {
                            return RedirectToAction("ListAgency", "Login");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Update không thành công");
                        }
                    }

                }
                catch
                {
                    if (ModelState.IsValid)
                    {

                        var model = new AccountModel();
                        var res = model.Update(property);

                        models.PROPERTY_FEATURE.RemoveRange(models.PROPERTY_FEATURE.Where(x => x.Property_ID == property.ID));
                        var features = Request.Form.AllKeys.Where(k => k.StartsWith("Feature_"));
                        foreach (var fea in features)
                        {
                            var ids = int.Parse(fea.Split('_')[1]);
                            if (Request.Form[fea].StartsWith("true"))
                            {
                                models.PROPERTY_FEATURE.Add(new PROPERTY_FEATURE
                                {
                                    Property_ID = property.ID,
                                    Feature_ID = ids

                                });
                            }

                        }
                        models.SaveChanges();

                        if (res)
                        {
                            return RedirectToAction("ListAgency", "Login");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Update không thành công");
                        }
                    }
                }
            }

            return View(property);
        }

        // GET: Admin/Property/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Admin/Property/Delete/5
        //[HttpPost]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new AccountModel().Delete(id);

            // return View("Index");
            return RedirectToAction("Index", "Property");

            //return View();

        }

        public void ListAll()
        {
            ViewBag.feature = models.FEATUREs.ToList();
            ViewBag.property_type = models.PROPERTY_TYPE.ToList();
            ViewBag.street = models.STREETs.OrderBy(x => x.StreetName).ToList();
            ViewBag.ward = models.WARDs.OrderBy(x => x.WardName).ToList();
            //ViewBag.district = models.DISTRICT_Table.OrderBy(x => x.DistrictName).ToList();
            ViewBag.district = models.DISTRICT_Table.OrderBy(x => x.DistrictName).ToList();
            ViewBag.user = models.USERs.OrderBy(x => x.FullName).ToList();
            ViewBag.status = models.PROJECT_STATUS.OrderBy(x => x.Status_Name).ToList();
            //ViewBag.sale = model.Sla.ToList();

        }
    }
}
