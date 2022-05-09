using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerformingValidationsDemo.Models
{
    public class UserDetails:IValidatableObject
    {
        [Required(ErrorMessage="User Name is Required")]
        [StringLength(15, ErrorMessage ="Username cannot be more than 15 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Required")]
        [StringLength(8, MinimumLength =4, ErrorMessage ="Password should be between 4 to 8 characters.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm New Password")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage ="Passwords don't Match")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Required")]
        [Display(Name ="Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:d}", ApplyFormatInEditMode=true)]
        public string DateOfBirth { get; set; }


        [Required(ErrorMessage = "Required")]
        [Display(Name ="Email Address")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Email not valid")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Required")]
        [Range(100,1000,ErrorMessage ="Postal Code need to be between 100 and 1000")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage ="Enter Valid Phone number")]
        public int PhoneNo { get; set; }


        [DataType(DataType.MultilineText)]
        public string Profile { get; set; }


        [FileExtensions (Extensions ="png,jpg,jpeg,gif")]
        public string Photo { get; set; }

        [AllowHtml()]
        [Display(Name ="Any Comments")]
        public string AdditionalComments { get; set; }


        [CustomValidation(typeof(CityValidator), "IsCityValid")]
        public string City { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            ValidationResult vr = null;

            if (City.ToLower() == "hyderabad" && PostalCode > 500)
                vr = new ValidationResult("Invalid PostalCode for Hyderabad City");

        }
    }
}