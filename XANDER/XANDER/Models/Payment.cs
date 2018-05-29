using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace XANDER.Models
{
    public class Payment
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Job")]
        public int JobID { get; set; }
        

    }
}