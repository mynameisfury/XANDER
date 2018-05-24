using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace XANDER.Models
{
    public class Job
    {
        [Key]
        public int ID { get; set; }

        public int ClientID { get; set; }
        [ForeignKey("ClientID")]
        public virtual Client Client { get; set; }

        public int? WorkerID { get; set; }
        [ForeignKey("WorkerID")]
        public virtual Worker Worker { get; set; }

        [StringLength(50)]
        [Display(Name = "Job name")]
        public string JobName { get; set; }

        [Display(Name = "Job type")]
        [ForeignKey("JobType")]
        public int JobTypeID { get; set; }
        public virtual JobType JobType { get; set; }

        [Display(Name = "Job description")]
        public string JobDescription { get; set; }

        [Display(Name = "Job payout")]
        public int JobPayout { get; set; }

        [Display(Name ="Due date")]
        public DateTime DueDate { get; set; }

        public bool Completed { get; set; }

        public bool Accepted { get; set; }

    }
}