using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practico.MvcMobile.Models;
using System.Web.Security;
using System.Net.Mail;
using System.Configuration;
using Practico.MvcMobile.DAL;
using System.Net;
using System.Data;
using System.Data.Entity.Infrastructure;
using Practico.MvcMobile.Helpers;

namespace Practico.MvcMobile.Controllers
{
    public class AccountController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /Account/
        /// <summary>
        /// Lista para cargar el dropdownlist en la vista Register
        /// </summary>
        public static IEnumerable<string> StudiesList = new List<string> 
        { 
            "Universitario",
            "Terciario",
            "Secundario"
        };

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Método HttpPost que loguea al usuario. Si es correcto, lo redirecciona al Index
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Vista de Login con el Model, solo si hubo algún error</returns>
        [HttpPost]
        public ActionResult Login(Login model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = unitOfWork.UserRepository.Get(x => x.Email == model.Username && x.Password == model.Password).FirstOrDefault();
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Username, true);
                        Session["User"] = user;
                        if (user.HasTakenTest == true)
                            Session["Test"] = user.Test;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                        throw new Exception("Usuario o contraseña incorrectos");
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorTitle = "ERROR";
                ViewBag.ErrorMessage = e.Message;
            }

            return View(model);
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Método que registra a un usuario nuevo. Recibe todo los datos necesarios. Verifica si el modelo
        /// es válido y si lo es, verifica que el usuario realmente sea nuevo y que el password se 
        /// haya generado correctamente. Luego envía un mail al usuario con la clave.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Vista de Registro con el modelo User, sólo si hubo un problema y no se pudo
        /// completar el registro
        /// </returns>
        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if ((unitOfWork.UserRepository.Get(x => x.DNI == user.DNI) != null))
                    {
                        if (user.SetPassword())
                        {
                            user.SetRegisterDate();
                            //Esto es lo nuevo. Implemetando Unit Of Work
                            unitOfWork.UserRepository.Insert(user);
                            unitOfWork.Save();
                            ViewBag.ErrorTitle = "Nuevo Usuario";
                            ViewBag.ErrorMessage = "Tu Usuario se creó correctamente. Se te envió un mail con tu clave.";
                            if (MailHelper.SendMail(user.Email, user.Password, user.Name, user.Lastname))
                            {
                                ViewBag.ErrorTitle = "Nuevo Usuario";
                                ViewBag.ErrorMessage = "Tu Usuario se creó correctamente. Se te envió un mail con tu clave. Revisá tu cuenta para poder ingresar al sistema";
                            }
                            else
                            {
                                ViewBag.ErrorTitle = "ERROR al enviar Clave de Acceso";
                                ViewBag.ErrorMessage = "No se pudo enviar tu clave de acceso por correo. Tu clave de acceso es: <br />" + user.Password + "<br /> Guardala en un lugar seguro!";
                            }
                        }
                        else
                            throw new Exception("No se pudo establecer un password correcto");
                    }
                    else
                        throw new Exception("Ya existe un Usuario con tu mismo DNI!");
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorTitle = "ERROR";
                ViewBag.ErrorMessage = e.Message;
            }
            return View();
        }

        // GET: /Account/Logout
        [Authorize]
        public ActionResult Logout()
        {
            Session["User"] = null;
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            return View();
        }

        // GET: /Account/EditProfile
        [Authorize]
        public ActionResult EditProfile(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = unitOfWork.UserRepository.GetByID(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult EditProfile(FormCollection model)
        {
                User userToUpdate = unitOfWork.UserRepository.GetByID(Convert.ToInt32(model["ID"]));
                if (userToUpdate != null)
                {
                    if (userToUpdate.Email != model["Email"].ToString())
                        userToUpdate.Email = model["Email"].ToString();
                    if (userToUpdate.Phone != model["Phone"].ToString())
                        userToUpdate.Phone = model["Phone"].ToString();
                    try
                    {
                        if (TryUpdateModel(userToUpdate))
                        {
                            try
                            {
                                unitOfWork.UserRepository.Update(userToUpdate);
                                unitOfWork.Save();
                                ViewBag.ErrorTitle = "Usuario Modificado";
                                ViewBag.ErrorMessage = "Modificaste tu cuenta correctamente";
                            }
                            catch (RetryLimitExceededException r)
                            {
                                //Log the error
                                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                                ViewBag.ErrorTitle = "ERROR";
                                ViewBag.ErrorMessage = r.Message;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        ViewBag.ErrorTitle = "ERROR";
                        ViewBag.ErrorMessage = e.Message;
                    }
                }
                return View(userToUpdate);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
