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
        public int RideID { get; set; }
        public string RideName { get; set; }

        [Range(1, 3,
            ErrorMessage = "Ride difficulty level must be between 1 and 3.")]
        public int RideDifficultyLevel { get; set; } = 1;

    }
}