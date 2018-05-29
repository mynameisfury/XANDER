using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace XANDER.Models
{
    public class Message
    {
        [Key]
        public int ID { get; set; }
        public string MessageBody { get; set; }
        public DateTime TimeStamp { get; set; }
        [ForeignKey("Client")]
        public int ClientID {get; set;}
        [ForeignKey("Worker")]
        public int WorkerID { get; set; }


    }
}