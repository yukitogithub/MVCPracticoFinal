using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Practico.MvcMobile.DAL;

namespace Practico.MvcMobile.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Se requiere tu password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage="Se requiere tu nombre de usuario (mail)")]
        [Display(Name = "Usuario")]
        public string Username { get; set; }

        /// <summary>
        /// Método que verifica si el usuario existe y si su nombre de usuario se corresponde con el password ingresado
        /// </summary>
        /// <returns>true: si el logueo es exitoso. false: si alguno de los campos es incorrecto</returns>
        public User VerifyUser()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            //DONE: La conexion string siempre debe estar en el webconfig.ByLucho
            //TODO: Sacar esto de acá y pasárselo al Controller apropiado
            //string conection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            //TODO: para el contexto podrias definirlo dentro de un singleton para no tener que instanciarlo todas las veces
            //using (var context = new Context(conection))
            //{
                //var repo = new Repository<User>(context);
                //DONE: estas haciendo un find primero pro passowrd y despues validas el email. Ponelo al revez, siempre el find por el 
                //user name o email y luego validas la password
                var aux = unitOfWork.UserRepository.Get(x => x.Email == this.Username && x.Password == this.Password).FirstOrDefault();
                if (aux != null)
                {
                    unitOfWork.Dispose();
                    return aux;
                }
                else
                {
                    unitOfWork.Dispose();
                    return null;
                }
            //}
        }
    }
}