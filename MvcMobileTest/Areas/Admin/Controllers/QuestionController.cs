using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practico.MvcMobile.DAL;
using System.Net;
using Practico.MvcMobile.Models;
using System.Data;
using Practico.MvcMobile.Areas.Admin.Models;

namespace Practico.MvcMobile.Areas.Admin.Controllers
{
    public class QuestionController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /Admin/Question/

        public ActionResult Index()
        {
            return View(unitOfWork.QuestionRepository.All().ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = unitOfWork.QuestionRepository.GetByID(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewQuestion question)
        {
            try
            {
                if (ModelState.IsValid)
                {
                //    //unitOfWork.QuestionRepository.Insert(question);
                //    //unitOfWork.Save();
                //    //return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(question);
        }

        public ActionResult EditQuestion(int id)
        {
            Question question = unitOfWork.QuestionRepository.GetByID(id);
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuestion(FormCollection form)
        {
            try
            {
                if (form != null)
                {
                    Question question = unitOfWork.QuestionRepository.GetByID(Convert.ToInt32(form["ID"]));
                    if (form["question"] != null && form["question"] != "")
                    {
                        question.question = form["question"];
                        unitOfWork.QuestionRepository.Update(question);
                        unitOfWork.Save();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                        return View(question);
                    }
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View();
        }

        public ActionResult EditAnswer(int id)
        {
            Answer answer = unitOfWork.AnswerRepository.GetByID(id);
            return View(answer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAnswer(FormCollection form)
        {
            try
            {
                if (form != null)
                {
                    Answer answer = unitOfWork.AnswerRepository.GetByID(Convert.ToInt32(form["ID"]));
                    if (form["answer"] != null && form["answer"] != "")
                    {
                        answer.answer = form["answer"];
                        unitOfWork.AnswerRepository.Update(answer);
                        unitOfWork.Save();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                        return View(answer);
                    }
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
