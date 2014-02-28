using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Practico.MvcMobile.Areas.Admin.Models
{
    public class NewQuestion
    {
        [Required]
        public string question { get; set; }
        [Required]
        public string answer1 { get; set; }
        public string Type1 { get; set; }
        [Required]
        public string answer2 { get; set; }
        public string Type2 { get; set; }
        [Required]
        public string answer3 { get; set; }
        public string Type3 { get; set; }
    }
}