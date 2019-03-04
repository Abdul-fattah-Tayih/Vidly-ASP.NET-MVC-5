using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMVC.Models
{
    public class Genre
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}