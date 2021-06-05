using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace press_Agency.Models
{
    public class Questions
    {
        [Key]
        public int id { get; set; }

        public string username { get; set; }


        public string editor_name { get; set; }

        public string Qusetions { get; set; }
        public string Answer { get; set; }

    }
}