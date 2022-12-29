using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Customer
    {
        public int Id { get; set; }       

        [Display(Name = "Name:")]
        [Required]
        //[Required(ErrorMessage = "The Name field is requiered.")] // MVC: 
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The Name field length must be between 3 and 100")]
        public string Name { get; set; }

        [Display(Name = "Family:")]
        [Required]
        [StringLength(200, MinimumLength = 4)]
        public string Family { get; set; }

        //[Required]
        //[StringLength(6, MinimumLength = 3)]
        //[System.Web.Mvc.Remote("IsUserAvailable", "Validation")]
        //[RegularExpression(@"(\S)+", ErrorMessage = "White space is not allowed.")]
        //[Editable(true)]
        //public string UserName { get; set; }

        //[RegularExpression (@"(A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}")]
        //public string Email { get; set;}

        [Display(Name = "News Subscribed:")]
        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }    // MVC: as refrence table for Forien Key MembershipTypeId

        [Display(Name = "Membership Type:")]
        public byte MembershipTypeId { get; set; }  // MVC: used as Forien Key refer to MembershipType



        [Required] 
        [Display(Name = "Date of Birth:")]       
        [Minimum18YearsIfAMemeberValidation]    // MVC: Custom Validation
        public DateTime? Birthdate { get; set; }        
    }
}