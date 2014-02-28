using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practico.MvcMobile.Models
{
    public class Question
    {
        public int ID { get; set; }
        public string question { get; set; }
        public virtual List<Answer> Answers { get; set; }
    }
}