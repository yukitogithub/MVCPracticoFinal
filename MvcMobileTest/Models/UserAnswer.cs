using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practico.MvcMobile.Models
{
    public class UserAnswer
    {
        public int ID { get; set; }
        public virtual Question Question { get; set; }
        public virtual Answer Answer { get; set; }
        public int PartialResult { get; set; }
    }
}