using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XANDER.Models
{
    public class File
    {
        [Key]
        public int ID { get; set; }
        public string FilePath { get; set; }
    }
}