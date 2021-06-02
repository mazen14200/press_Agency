using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using press_Agency.Controllers;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace press_Agency.Models
{
    public class user_login
    {

        [Key]
        [Required]
        /*
        [Compare("username", ErrorMessage = "Email is not matched")] // momken adef errormassage bardo ade we momken la adee
        */
        public string username { get; set; }
        [EmailAddress] 
        public string Email { get; set; }
        [Required]
        /*
        [Compare("ttr", ErrorMessage = "Email is not matched")] // momken adef errormassage bardo ade we momken la adee
        */

        public string password { get; set; }




    }

    internal class displayAttribute : Attribute
    {
    }
}