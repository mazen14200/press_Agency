using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace press_Agency.Models
{
    public class post
    {

        public string artical_Title { get; set; }
        [StringLength(2000)]
        public string artical_Body { get; set; }
        public DateTime postCreationDate { get; set; }
        public string artical_Type { get; set; }
        public int? NumberOfViewers { get; set; }

        [StringLength(2000), DisplayName("upload Image")]
        public string artical_image { get; set; }
        [Key]
        public int id { get; set; }
        public user editor_name { get; set; }
        public string editor_username { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

    }
}