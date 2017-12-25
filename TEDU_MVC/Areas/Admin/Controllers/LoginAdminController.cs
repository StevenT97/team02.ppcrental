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

namespace TEDU_MVC.Areas.Admin.Controllers
{
    public class LoginAdminController : Controller
    {
        // GET: Admin/LoginAdmin
        List<SelectListItem> propertytype;
        DemoPPCRentalEntities model = new DemoPPCRentalEntities();
        // GET: Admin/Login
        DemoPPCRentalEntities db = new DemoPPCRentalEntities();
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/LoginAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                    userSession.FullName = user.FullName;
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

        // GET: Admin/LoginAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoginAdmin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/LoginAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/LoginAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/LoginAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/LoginAdmin/Delete/5
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
