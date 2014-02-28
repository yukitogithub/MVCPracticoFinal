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
    public class TestController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /Admin/Test/

        public ActionResult Index()
        {
            return View();
        }

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

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
