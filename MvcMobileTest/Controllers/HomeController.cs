using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practico.MvcMobile.Models;
using System.Configuration;
using Practico.MvcMobile.DAL;
using System.Web.Security;
using System.Net;

namespace Practico.MvcMobile.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /Home/

        public ActionResult NoJS()
        {
            if (Session["User"] != null)
            {
                Session["User"] = null;
            }
            return View();
        }

        /// <summary>
        /// Método para cargar el index. Verifica la autorización del usuario.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Index()
        {
            if (Session["User"] != null)
            {
                User user = Session["User"] as User;
                if (user.HasTakenTest == true)
                {
                    if (Session["Test"] != null)
                    {
                        Test test = Session["Test"] as Test;
                        ViewBag.TestResult = test.Result;
                    }
                    else
                    {
                        return RedirectToAction("Logout", "Account");
                    }
                }
                return View(user);
            }
            else
                return RedirectToAction("Logout", "Account");
            return View();
        }

        [Authorize]
        public ActionResult CreateTest()
        {
            if (Session["User"] != null)
            {
                User user = Session["User"] as User;
                if (user.Test == null)
                {
                    unitOfWork.UserRepository.Update(user);
                    user.Test = new Test();
                    user.Test.Date = DateTime.Today;
                    user.Test.Result = 0;
                    user.Test.Questions = new List<Question>();
                    Random rnd = new Random();
                    int a = unitOfWork.QuestionRepository.All().Count();
                    for (int i = 1; i <= Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["NumberOfQuest"]); i++)
                    {
                        int aux = rnd.Next(1,a);
                        while (user.Test.Questions.Find(x => x.ID == aux) != null)
                            aux = rnd.Next(1,a);
                        Question q = unitOfWork.QuestionRepository.GetByID(aux);
                        user.Test.Questions.Add(q);
                    }
                    Session["Test"] = user.Test;
                    if (TryUpdateModel(user))
                    {
                        try
                        {
                            unitOfWork.Save();
                        }
                        catch (Exception e)
                        {
                            Response.Write("ERROR");
                        }
                    }
                }
                ViewBag.ActualQuestionNumber = 1;
                return RedirectToActionPermanent("Test","Home");
            }
            else
                return RedirectToAction("Logout", "Account");
        }

        [Authorize]
        public ActionResult Test()
        {
            if (Session["User"] != null)
            {
                User user = Session["User"] as User;
                if (user.Test == null)
                {
                    CreateTest();
                    return RedirectToAction("Test", "Home");
                }
                else
                {
                    if (user.HasTakenTest == false)
                    {
                        if (Session["Test"] != null)
                        {
                            unitOfWork.UserRepository.Update(user);
                            user.HasTakenTest = true;
                            if (TryUpdateModel(user))
                            {
                                try
                                {
                                    unitOfWork.Save();
                                }
                                catch (Exception e)
                                {
                                    Response.Write("ERROR");
                                }
                            }
                            ViewBag.ActualQuestionNumber = 1;
                            ViewBag.Time = DateTime.Now.TimeOfDay;
                            Test test = Session["Test"] as Test;
                            List<Answer> answers = new List<Answer>();
                            Question ques = unitOfWork.QuestionRepository.GetByID(test.Questions[0].ID);
                            foreach (Answer a in ques.Answers)
                            {
                                answers.Add(a);
                            }
                            Session["Answers"] = null;
                            Session["Answers"] = answers;
                            return View(test);
                        }
                        else
                        {
                            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                        }
                    }
                    else
                    {
                        User usertmp = Session["User"] as User;
                        User userupdtd = unitOfWork.UserRepository.GetByID(usertmp.ID);
                        Session["User"] = userupdtd;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                return RedirectToAction("Logout", "Account");
            }
            //return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Question(string question, string answer, string actualquestionnumber, string actualtime, string method)
        {
            if (Session["User"] != null)
            {
                User usertmp = Session["User"] as User;
                if (usertmp.HasTakenTest != false)
                {
                    if (Session["Test"] != null)
                    {
                        Test test = Session["Test"] as Test;
                        int aqn = Convert.ToInt32(actualquestionnumber) - 1;
                        //TODO: Ver si puedo poner el tiempo en una variable de acá
                        DateTime time = Convert.ToDateTime(actualtime);
                        if (test.userAnswer == null)
                        {
                            test.userAnswer = new List<UserAnswer>();
                        }
                        //Corroboro que la respuesta se haya hecho dentro del tiempo permitido, para ello, lo resto
                        TimeSpan resta = (DateTime.Now - time);
                        //Extraigo del web.config el tiempo permitido para responder una pregunta
                        TimeSpan second = TimeSpan.FromMilliseconds(Convert.ToInt32(ConfigurationManager.AppSettings["TimePerAnswer"]));
                        //Añado unos segundos adicionales por las dudas. De todas maneras, son un poco de segundos nada más.
                        second = second + TimeSpan.FromSeconds(45);
                        //Corrobor que la resta sea menor o igual al tiempo permitido
                        if (resta <= second && resta > TimeSpan.Zero)
                        {
                            //Corroboro que el núm de la pregunta actual se corresponda con la cantidad ya contestada
                            if (aqn == test.userAnswer.Count())
                            {
                                //Corroboro que no me jodan y quieran pasar un id de una pregunta ya contestada
                                if (test.userAnswer.Find(x => x.Question.ID == unitOfWork.QuestionRepository.GetByID(Convert.ToInt32(question)).ID) != null)
                                    return Json(new { error = "Hubo un Error. ¿Estás intentando responder preguntas anteriores? Intentalo Nuevamente o contactate con el administrador del sitio" });
                                unitOfWork.TestRepository.Update(test);
                                UserAnswer useranswer = new UserAnswer();
                                useranswer.Question = unitOfWork.QuestionRepository.GetByID(Convert.ToInt32(question));
                                //Corroboro que el id de la question que se pasa realmente exista
                                if (useranswer.Question == null)
                                    return Json(new { error = "Hubo un Error. Intentalo Nuevamente o contactate con el administrador del sitio" });
                                //Tratamiento de la respuesta según el botón que se hace click (Save = guardar la respuesta y devolver la siguiente, End && answer!=0 = Terminar el test guardando la última respuesta seleccionada)
                                if (method == "Save" || (method == "End" && answer != "0"))
                                {
                                    //Busco la respuesta elegida. De paso corroboro que realmente sea una respuesta de la pregunta actual
                                    useranswer.Answer = useranswer.Question.Answers.Find(x => x.ID == Convert.ToInt32(answer));
                                    //Si es nulo quiere decir que no se corresponde con la pregunta actual
                                    if (useranswer.Answer == null)
                                        return Json(new { error = "Hubo un Error. Intentalo Nuevamente o contactate con el administrador del sitio" });
                                    //Tratamiento del resultado, según la respuesta elegida
                                    if (useranswer.Answer.Type == true)
                                        //El score por cada respuesta acertada está en el WebConfig
                                        useranswer.PartialResult = Convert.ToInt32(ConfigurationManager.AppSettings["ScorePerGoodAnswer"]);
                                    else
                                        useranswer.PartialResult = 0;
                                }
                                //Tratamiento de la respuesta según el botón que se hace click (Next = devolver la siguiente question sin guardar la respuesta actual, End && answer==0 = Terminar el test sin guardar la última respuesta seleccionada)
                                if (method == "Next" || (method == "End" && answer == "0"))
                                {
                                    useranswer.Answer = null;
                                    useranswer.PartialResult = 0;
                                }
                                //Actualizo el resultado total del Test
                                test.Result += useranswer.PartialResult;
                                //Añado la respuesta del usuario al test, así se guarda en la base de datos
                                test.userAnswer.Add(useranswer);
                                aqn++;
                                if (method == "End")
                                {
                                    //Si eligió terminar, guardo las preguntas que no contestó y de respuesta NULL.
                                    //De esa manera tengo guardadas todas las preguntas
                                    int x = Convert.ToInt32(ConfigurationManager.AppSettings["NumberOfQuest"]) - aqn;
                                    for (int i = 1; i <= x; i++)
                                    {
                                        UserAnswer ua = new UserAnswer();
                                        Question Q = test.Questions[aqn + i - 1];
                                        ua.Question = unitOfWork.QuestionRepository.GetByID(Q.ID);
                                        test.userAnswer.Add(ua);
                                    }
                                    //Guardo en Session["User"] el usuario actualizado, para que cuando redireccione al index devueva la pag
                                    //Con la imagen para cuando el usuario ya hizo el Test
                                    User usertemp = Session["User"] as User;
                                    User userupdated = unitOfWork.UserRepository.GetByID(usertemp.ID);
                                    Session["User"] = userupdated;
                                    unitOfWork.Save();
                                    return Json(new { error = "", message = "Has decidido terminar el test", result = useranswer.PartialResult, testresult = test.Result });
                                }
                                else
                                {
                                    unitOfWork.Save();
                                    //Si eligió seguir, evalúo que no se hayan terminado las preguntas del test
                                    if (aqn < Convert.ToInt32(ConfigurationManager.AppSettings["NumberOfQuest"]))
                                    {
                                        Question questionback = test.Questions[aqn];
                                        questionback = unitOfWork.QuestionRepository.GetByID(questionback.ID);
                                        //Aumento en uno el número de la pregunta actual
                                        aqn++;
                                        return Json(new { question = questionback, aqn = aqn, at = DateTime.Now.TimeOfDay.ToString(), result = useranswer.PartialResult, error = "", message = "" });
                                    }
                                    else
                                    {
                                        return Json(new { error = "", message = "Terminaste el Test! Tu resultado fue satisfactorio", result = useranswer.PartialResult, testresult = test.Result });
                                    }
                                }
                            }
                            else
                            {
                                //Guardo todas las respuestas, en caso de haber un error o de que el usuario haya elegido
                                //salir de la página. El método se llama con el evento onunload de javascript
                                unitOfWork.TestRepository.Update(test);
                                int index = test.userAnswer.Count();
                                int x = Convert.ToInt32(ConfigurationManager.AppSettings["NumberOfQuest"]) - index;
                                for (int i = 1; i <= x; i++)
                                {
                                    UserAnswer ua = new UserAnswer();
                                    Question Q = test.Questions[index + i - 1];
                                    ua.Question = unitOfWork.QuestionRepository.GetByID(Q.ID);
                                    test.userAnswer.Add(ua);
                                }
                                unitOfWork.Save();
                                //Devulevo un error si la cantidad de preguntas contestadas no se corresponden con el número de la pregunta actual, por si acaso
                                return Json(new { error = "Hubo un Error. Intentalo Nuevamente o contactate con el administrador del sitio" });
                            }
                        }
                        else
                        {
                            //Tratamiento del test si la cantidad de segundos es distinta de 45.
                            //Quiere decir que pasó más de 45 segundos desde que se le dió la pregunta y contestó
                            //Probablemente porque desactivó el javascript, para detener el timer
                            return Json(new { error = "Hubo un Error. Intentalo Nuevamente o contactate con el administrador del sitio" });
                        }
                    }
                }
                else
                {
                    User userupdtd = unitOfWork.UserRepository.GetByID(usertmp.ID);
                    Session["User"] = userupdtd;
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Logout", "Account");
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
