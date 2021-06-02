using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace press_Agency.Models
{
    public class user
    {
        [Required]

        public string Fname { get; set; }
        [Required]

        public string Lname { get; set; }
        [Key]
        [Required]
        public string username { get; set; }
        [EmailAddress] 
        [Required]
        public string Email { get; set; }
        [Required]
        public string password { get; set; }
        [Phone]
        [Required]
        public string phoneNumber { get; set; }
        


        [StringLength(2000), DisplayName("upload Image")]
        public string photo { get; set; }
        

        public string userRole { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }



    }
}