using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoGrid.Models
{
    [Table("AthleteData")]
    public class AthletesModel
    {
        [Key]        
        public int? AthleteID { get; set; }

        [Required(ErrorMessage = "Athlete Name Required")]
        public string AthleteName { get; set; }

        [Required(ErrorMessage = "Athlete Age Required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Athlete Country Required")]
        public string Country { get; set; }

        
       
        public DateTime ClosingCeremonyDate { get; set; }

        [Required(ErrorMessage = "Athlete Sport Required")]
        public string Sport { get; set; }

        [Required(ErrorMessage = "Athlete GoldMedal Required")]
        public int GoldMedal { get; set; }

        [Required(ErrorMessage = "Athlete SilverMedal Required")]
        public int SilverMedal { get; set; }

        [Required(ErrorMessage = "Athlete BronzeMedal Required")]
        public int BronzeMedal { get; set; }

        [Required(ErrorMessage = "Athlete Total Medals Required")]
        public int TotalMedals { get; set; }

    }
}