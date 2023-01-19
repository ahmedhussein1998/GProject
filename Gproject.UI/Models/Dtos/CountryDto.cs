using System.ComponentModel.DataAnnotations;

namespace Gproject.UI.Models.Dtos
{
    public class CountryDto
    {

            public Guid Id { get; init; }


            [Display(Name = "Country Arabic Name *")]
            [Required(ErrorMessage = "Mandatory feild")]
            //[StringLength(50, ErrorMessage = "The name must not exceed 50 characters")]
            //[RegularExpression("^[\u0621-\u064A0-9 ]+$", ErrorMessage = "Only Arabic letters, numbers and spaces are allowed")]
            public string NameAr { get; set; }

            [Display(Name = "Country English Name *")]
            [Required(ErrorMessage = "Mandatory feild")]
            //[StringLength(50, ErrorMessage = "The name must not exceed 50 characters")]
            //[RegularExpression("^[0-9A-Za-z ]+$", ErrorMessage = "Only English letters, numbers and spaces are allowed")]
            public string NameEn { get; set; }

            [Display(Name = "Activity Status *")]
            public bool IsActive { get; init; } = true;

            [Display(Name = "OrderIndex *")]
            //[Required(ErrorMessage = "Mandatory feild")]
            //[Range(1, 1000, ErrorMessage = "The Order Index must Be In Range From 1 To 1000")]
            public int OrderIndex { get; init; }

            [Display(Name = "Postal Code")]
            //[RegularExpression(@"^(\d{5})$", ErrorMessage = "Enter a valid 5 digit")]
            public string PostalCode { get; init; }

      

    }
}
