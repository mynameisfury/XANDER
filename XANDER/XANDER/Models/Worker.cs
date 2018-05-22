using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XANDER.Models
{
    public class Worker
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Profile Description")]
        public string ProfileDescription { get; set; }
        public int Rating { get; set; }


    }
}