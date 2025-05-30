using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Novus_Catalog.Models
{
    public class Students_Deleted
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int sid { get; set; }

        public string sfirstname { get; set; }

        public string slastname { get; set; }

        public string gender { get; set; }

        public string address { get; set; }

        public string city { get; set; }

        public string department { get; set; }

        public string school { get; set; }

        public string pfirstname { get; set; }

        public string plastname { get; set; }

        [Column("DATE_ENROLLED")]
        public string dateEnrolled { get; set; }

        [Column("PHONE_NUMBER")]
        public string phoneNumber { get; set; }

        public string attendance { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:yyyy-MM-ddTHH:mm:ss:zzz}")]
        public DateTime createdDateTime { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:yyyy-MM-ddTHH:mm:ss:zzz}")]
        public DateTime modifiedDateTime { get; set; }
    }
}