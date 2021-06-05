using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace press_Agency.Models
{
    public class Savedposts
    {
        [Key]

        public int id { get; set; }
        public string user_name { get; set; }
        public string artical_Title { get; set; }
        [StringLength(2000)]
        public string artical_Body { get; set; }
        public DateTime postCreationDate { get; set; }
        public string artical_Type { get; set; }
        public int? NumberOfViewers { get; set; }

        [StringLength(2000), DisplayName("upload Image")]
        public string artical_image { get; set; }
        public string editor_name { get; set; }
        public string post_status { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public int num_of_likes { get; set; }
        public int num_of_dislikes { get; set; }
    }
}