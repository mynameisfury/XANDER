using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XANDER.Models
{
    public class JobType
    {
        [Key]
        public int ID { get; set; }
        public string Type { get; set; }
    }
}