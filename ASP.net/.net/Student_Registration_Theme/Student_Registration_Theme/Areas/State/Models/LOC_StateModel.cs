using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Student_Registration_Theme.Areas.State.Models
{
    public class LOC_StateModel
    {
        public int StateID { get; set; }
        [Required]
        [DisplayName("State Name")]
        public string? StateName { get; set; }

        [Required]
        [DisplayName("Country ID")]
        public int? CountryID { get; set; }

        [Required]
        [DisplayName("State Code")]
        public string? StateCode { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

    public class LOC_State_DropdownModel
    {
        public int StateID { get; set; }
        public string? StateName { get; set; }
    }
}
