using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace XANDER.Models
{
    public class Review
    {
        [Key]
        public int ID { get; set; }

        public int ClientID { get; set; }
        [ForeignKey("ClientID")]
        public virtual Client Client { get; set; }


        [ForeignKey("Worker")]
        public int WorkerID { get; set; }
        public virtual Worker Worker { get; set; }

        public int JobID { get; set; }
        [ForeignKey("Job")]
        public virtual Job Job { get; set; }

        public string ReviewText { get; set; }
        public int Score { get; set; }


    }
}