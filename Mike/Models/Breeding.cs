using System;
using System.ComponentModel.DataAnnotations;


namespace Mike.Models
{
    public class Breeding
    {
        public int Id { get; set; }
        [Display(Name = "Rasa")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string DogRace { get; set; }
        [Display(Name = "Imię")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string DogName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data urodzenia")]
        public DateTime BirthDate { get; set; }

    }
}
