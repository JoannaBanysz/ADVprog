using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mike.Models
{
    public class Fodder
    {
        public int Id { get; set; }
        [Display(Name = "Producent")]
        public string Producer { get; set; }
        [Display(Name = "Produkt")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data produkcji")]
        public DateTime ProductionDate { get; set; }
        [Range(0,1000), DataType(DataType.Currency)]
        [Display(Name = "Cena")]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }

    }
}
