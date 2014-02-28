using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practico.MvcMobile.Models
{
    public class Test
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        [NotMapped]
        public virtual List<Question> Questions { get; set; }

        public virtual List<UserAnswer> userAnswer { get; set; }

        public int Result { get; set; }
    }
}