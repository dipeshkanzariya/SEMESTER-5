using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Student_Registration_Theme.Areas.City.Models
{
    public class LOC_CityModel
    {
        [Required]
        public int CityID { get; set; }

        [Required]
        [DisplayName("City Name")]
        public string? CityName { get; set; }

        [Required]
        [DisplayName("City Code")]
        public string? CityCode { get; set; }

        [Required]
        [DisplayName("State")]
        public int? StateID { get; set; }

        [Required]
        [DisplayName("Coutnry")]
        public int? CountryID { get; set; }

    }

    public class LOC_CityDropdownModel
    {
        public int? CityID { get; set; }

        public string? CityName { get; set; }
    }
}
