using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Practico.MvcMobile.DAL;

namespace Practico.MvcMobile.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        [MinLength(4)]
        [Display(Name="Nombre")]
        public string Name { get; set; }

        [Required]
        [MinLength(4)]
        [Display(Name = "Apellido")]
        public string Lastname { get; set; }

        [Required]
        [StringLength(8,MinimumLength=8)]
        [Display(Name = "Documento")]
        public string DNI { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Formato Incorrecto")]
        [Display(Name = "Fecha Nac.")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Estudios")]
        public string Studies { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Formato de Email Incorrecto")]
        [RegularExpression(@"^(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})$",ErrorMessage="Formato de Email Incorrecto")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber,ErrorMessage="Formato Incorrecto")]
        [Display(Name = "Celular")]
        public string Phone { get; set; }

        [Required]
        [MinLength(4)]
        [Display(Name = "Provincia")]
        public string Province { get; set; }

        [Required]
        [MinLength(4)]
        [Display(Name = "Ciudad")]
        public string City { get; set; }

        [DataType(DataType.Password, ErrorMessage = "Formato Incorrecto")]
        public string Password { get; set; }

        public DateTime RegisterDate { get; set; }
        public bool HasTakenTest { get; set; }

        public virtual Test Test { get; set; }
        
        /// <summary>
        /// Método para asignar la fecha del día al usuario que se registra
        /// </summary>
        public void SetRegisterDate()
        {
            this.RegisterDate = DateTime.Now;
        }

        /// <summary>
        /// Método para asignarle un password al usuario que se registra
        /// </summary>
        /// <returns>
        /// true: si ninguno de los campos está vacío. false: si hay algún error
        /// </returns>
        public bool SetPassword()
        {
            if (this.DNI != null & this.Name != null & this.Lastname != null)
            {
                Password = DNI.Substring(4, 4) + "0000" + Name.First() + Lastname.First();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}