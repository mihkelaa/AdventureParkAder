using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdventurePark.Models
{
    public class Rides
    {
        [Key]
        public int RideID { get; set; } //Peavõti Sõitudele
        public string RideName { get; set; }  //Sõidu nimetus

        [Range(1, 3,
            ErrorMessage = "Ride difficulty level must be between 1 and 3.")] //Kui raskusaste ei ole vastav arv, tuleb viga
        public int RideDifficultyLevel { get; set; } = 1; //Raskusaste 

    }
}