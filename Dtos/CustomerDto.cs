using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MVC.Models;

namespace MVC.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        // MVC: [Required(ErrorMessage = "The Name field is requiered.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The Name field length must be between 3 and 100")]
        public string Name { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 4)]
        public string Family { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

       
        public byte MembershipTypeId { get; set; }  // MVC: used as Forien Key refer to MembershipType

        public MembershipTypeDto MembershipType { get; set; } // MVC: API: add for showing MembershipType stored in seperate table

        [Required]
        //[Minimum18YearsIfAMemeberValidation]    // MVC: Custom Validation
        public DateTime? Birthdate { get; set; }
    }
}