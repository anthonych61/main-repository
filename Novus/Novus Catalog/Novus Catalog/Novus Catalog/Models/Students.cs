using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Novus_Catalog.Models
{
    public class Students
    {       
        [Key]
        public int sid { get; set; }

        [Required(ErrorMessage = "Firstname required.")]
        [StringLength(15, ErrorMessage ="Firstname cannot exceed 15 characters.")]
        public string sfirstname { get; set; }

        [Required(ErrorMessage = "Lastname required.")]
        [StringLength(15, ErrorMessage = "Lastname cannot exceed 15 characters.")]
        public string slastname { get; set; }

        [Required(ErrorMessage = "Gender required.")]
        public string gender { get; set; }

        [StringLength(35, ErrorMessage = "Address cannot exceed 35 characters.")]
        public string address { get; set; }

        [StringLength(25, ErrorMessage = "City cannot exceed 25 characters.")]
        public string city { get; set; }

        [StringLength(5, ErrorMessage = "Department cannot exceed 5 characters.")]
        public string department { get; set; }

        [StringLength(35, ErrorMessage = "School cannot exceed 35 characters.")]
        public string school { get; set; }

        [StringLength(15, ErrorMessage = "Parent firstname cannot exceed 15 characters.")]
        public string pfirstname { get; set; }

        [StringLength(15, ErrorMessage = "Parent lastname cannot exceed 15 characters.")]
        public string plastname { get; set; }

        [Required(ErrorMessage = "Date required.")]
        [Column("DATE_ENROLLED"), StringLength(13, ErrorMessage = "Date cannot exceed 13 characters.")]
        public string dateEnrolled { get; set; }

        [Column("PHONE_NUMBER"), StringLength(14, ErrorMessage = "Phonenumber cannot exceed 14 characters.")]
        public string phoneNumber { get; set; }

        [Required(ErrorMessage = "Attendance required.")]
        public string attendance { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:yyyy-MM-ddTHH:mm:ss:zzz}")]
        public DateTime createdDateTime { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:yyyy-MM-ddTHH:mm:ss:zzz}")]
        public DateTime modifiedDateTime { get; set; }

        public Students() {}
        public Students(int sid, string sfirstname, string slastname, string gender, string address, string city, string department, string school, string pfirstname, string plastname, string dateEnrolled, string phoneNumber, string attendance, DateTime createdDateTime, DateTime modifiedDateTime)
        {
            this.sid = sid;
            this.sfirstname = sfirstname;
            this.slastname = slastname;
            this.gender = gender;
            this.address = address;
            this.city = city;
            this.department = department;
            this.school = school;
            this.pfirstname = pfirstname;
            this.plastname = plastname;
            this.dateEnrolled = dateEnrolled;
            this.phoneNumber = phoneNumber;
            this.attendance = attendance;
            this.createdDateTime = createdDateTime;
            this.modifiedDateTime = modifiedDateTime;
        }

    }
}