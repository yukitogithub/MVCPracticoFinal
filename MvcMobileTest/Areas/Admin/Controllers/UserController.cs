using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practico.MvcMobile.DAL;
using System.Net;
using Practico.MvcMobile.Models;

namespace Practico.MvcMobile.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /Admin/User/

        [Authorize]
        public ActionResult Index()
        {
            return View(unitOfWork.UserRepository.All().ToList());
        }

        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = unitOfWork.TestRepository.GetByID(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        [Authorize]
        public ActionResult NullTest(int id)
        {
            try
            {
                User user = unitOfWork.UserRepository.GetByID(id);
                user.HasTakenTest = false;
                int testid = user.Test.ID;
                user.Test = null;
                unitOfWork.UserRepository.Update(user);
                unitOfWork.Save();
                unitOfWork.TestRepository.Delete(testid);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
