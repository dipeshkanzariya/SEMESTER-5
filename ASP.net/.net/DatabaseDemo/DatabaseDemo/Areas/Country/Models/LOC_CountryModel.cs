using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DatabaseDemo.Areas.Country.Models
{
    public class LOC_CountryModel
    {
        public int CountryID { get; set; }

        [Required]
        [DisplayName("Country Name")]
        public string? CountryName { get; set; } 
        public string? CountryCode { get; set; }
        public DateTime? Created { get; set;}
        public DateTime? Modified { get; set;}

    }

    public class LOC_Country_DropdownModel
    {
        public int CountryID { get; set; }
        public string? CountryName { get; set; }
    }
}
