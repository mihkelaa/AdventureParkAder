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
        public int VisitorID { get; set; } //Külastaja peavõti
        public string VisitorFirstName { get; set; } //Külastaja Eesnimi
        public string VisitorLastName { get; set; } //Külastaja Perenimi
        public int VisitorAge { get; set; } //Külastaja vanus
    }
}