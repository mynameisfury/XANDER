using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XANDER.Models
{
    public class Job
    {
        [Key]
        public int ID { get; set; }
        public string JobName { get; set; }
        public string JobDescription { get; set; }
        public int JobPayout { get; set; }

    }
}