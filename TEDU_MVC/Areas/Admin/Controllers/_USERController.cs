using Models;
using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEDU_MVC.Areas.Admin.Models;
using TEDU_MVC.Code;

namespace TEDU_MVC.Areas.Admin.Controllers
{
    public class _USERController : BaseController
    {
        // GET: Admin/_USER
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/_USER/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/_USER/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/_USER/Create
        [HttpPost]
        public ActionResult Create(USER collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var db = new DemoPPCRentalEntities();

                    var encryptedMd5Pas = MaHoa.MD5Hash(collection.Password);
                    collection.Password = encryptedMd5Pas;
                    //db.USER_TABLE.Add(collection);
                    //db.SaveChangesAsync();
                    var dao = new AccountModel();
                    long id = dao.Insert(collection);
                    if (id > 0)
                    {
                        return RedirectToAction("Index", "_USER");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm user không thành công");
                    }

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: Admin/_USER/Edit/5
       
        public ActionResult Edit(int id)
        {
            var user = new AccountModel().EditUser(id);
            return View(user);
        }

        // POST: Admin/_USER/Edit/5

      
        [HttpPost]
        [ClearModelErrors]
        public ActionResult Edit(int id, USER users)
        {
            if (users.FullName == null)
            {
                ModelState.AddModelError("FullName", "FullName không được trống");
            }
            else if (users.FullName.Length > 50)
            {
                ModelState.AddModelError("FullName", "Không được quá 50 ký tự");
            }
            if (users.Phone == null)
            {
                ModelState.AddModelError("Phone", "Phone không được trống");
            }
            else if (users.Phone.Length > 15)
            {
                ModelState.AddModelError("Phone", "Không được quá 15 ký tự");
            }
            if (users.Address == null)
            {
                ModelState.AddModelError("Address", "Address không được trống");
            }
            else if (users.Address.Length > 50)
            {
                ModelState.AddModelError("Address", "Không được quá 100 ký tự");
            }

            if (ModelState.IsValid)
                {

                    var model = new AccountModel();
                    var res = model.UpdateUser(users);
                    if (res)
                    {
                        return RedirectToAction("EDIT","_USER");
                    }
                    
                    else
                    {
                        ModelState.AddModelError("", "Update không thành công");
                    }
                        }
           
            return View();

        }

        // GET: Admin/_USER/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/_USER/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
