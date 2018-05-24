using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace XANDER.Models
{
    public class Worker
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string UserID { get; set; }
        
        [Display(Name = "Profile Description")]
        public string ProfileDescription { get; set; }
        public int? Rating { get; set; }
        [ForeignKey("WorkerType")]
        public int WorkerTypeID { get; set; }
        public virtual WorkerType WorkerType { get; set; }
    }
}