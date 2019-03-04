using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class Customer
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YrsValidation]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Subscribe to news letter?")]
        public bool IsSubscribed { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Select Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}