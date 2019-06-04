using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdventurePark.Models
{
    public class Visitors
    {
        [Key]
        public int VisitorID { get; set; }
        public string VisitorFirstName { get; set; }
        public string VisitorLastName { get; set; }
        public int VisitorAge { get; set; }
    }
}