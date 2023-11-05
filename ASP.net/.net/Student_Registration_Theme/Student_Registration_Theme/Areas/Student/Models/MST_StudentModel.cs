using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Student_Registration_Theme.Areas.Student.Models
{
    public class MST_StudentModel
    {

        [Required]
        public int? StudentID { get; set; }

        [Required]
        [DisplayName("Student Name")]
        public string? StudentName { get; set; }


        [Required]
        [DisplayName("Country")]
        public int? BranchID { get; set; }


        [Required]
        [DisplayName("City")]
        public int? CityID { get; set; }


        public int? CountryID { get; set; }


        [Required]
        [DisplayName("Mobile No. of Studnet")]
        public string? MobileNoStudent { get; set; }

        [Required]
        [DisplayName("Mobile No. of Father")]
        public string? MobileNoFather { get; set; }


        [Required]
        [DisplayName("Email")]
        public string? Email { get; set; }

        [Required]
        [DisplayName("Address")]
        public string? Address { get; set; }


        [Required]
        [DisplayName("Birth date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [DisplayName("Age")]
        public int? Age { get; set; }


        [Required]
        [DisplayName("Is active")]
        public bool? IsActive { get; set; }


        [Required]
        [DisplayName("Gender")]
        public string? Gender { get; set; }


        [Required]
        [DisplayName("Password")]
        public string? Password { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

    }
}
