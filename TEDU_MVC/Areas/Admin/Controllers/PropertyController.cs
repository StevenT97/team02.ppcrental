using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Models.FrameWork;
using System.IO;
using TEDU_MVC.Code;

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
        public ActionResult Edit(PROPERTy property, List<HttpPostedFileBase> files)
        {
            ListAll();

            // Images

            try
            {
                if (files[0]!= null)
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
            } catch (Exception exx)
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



                // Xu ly Images

                //string filename = Path.GetFileNameWithoutExtension(property.ImageFile.FileName);
                //string extension = Path.GetExtension(property.ImageFile.FileName);
                //filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                //property.Images = filename;
                //filename = Path.Combine(Server.MapPath("~/Images"), filename);
                //property.ImageFile.SaveAs(filename);

                // End Xu ly Images



                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var model = new AccountModel();
                    var res = model.Update(property);
                    if (property.listfeature != null)
                    {
                        models.PROPERTY_FEATURE.RemoveRange(models.PROPERTY_FEATURE.Where(x => x.Property_ID == property.ID));
                        PROPERTY_FEATURE pf = new PROPERTY_FEATURE();

                        foreach (string x in property.listfeature)
                        {
                            pf.Property_ID = property.ID;
                            pf.Feature_ID = int.Parse(x);
                            models.PROPERTY_FEATURE.Add(pf);
                            models.SaveChanges();
                        }
                    }
                    if (res)
                    {
                        return RedirectToAction("Index", "Property");
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

                    if (property.listfeature != null)
                    {
                        models.PROPERTY_FEATURE.RemoveRange(models.PROPERTY_FEATURE.Where(x => x.Property_ID == property.ID));
                        PROPERTY_FEATURE pf = new PROPERTY_FEATURE();

                        foreach (string x in property.listfeature)
                        {
                            pf.Property_ID = property.ID;
                            pf.Feature_ID = int.Parse(x);
                            models.PROPERTY_FEATURE.Add(pf);
                            models.SaveChanges();
                        }
                    }

                    if (res)
                    {
                        return RedirectToAction("Index", "Property");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Update không thành công");
                    }
                }
            }

            return View("Index");

            // return View("Index");
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
            ViewBag.district = models.DISTRICT_Table.Where(x => x.ID > 31 && x.ID < 45).OrderBy(x => x.DistrictName).ToList();
            ViewBag.user = models.USERs.OrderBy(x => x.FullName).ToList();
            ViewBag.status = models.PROJECT_STATUS.OrderBy(x => x.Status_Name).ToList();
            //ViewBag.sale = model.Sla.ToList();

        }
    }
}
