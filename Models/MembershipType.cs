using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public string Name { get; set; }

        public short SignUpFee { get; set; }

        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }

        // MVC: Refactoring Magic Numbers solution:
        // MVC: for replacing 0 and 1 in code within Minimum18YearsIfAMemeberValidation.cs
        public static readonly byte UnKnown = 0;
        public static readonly byte FreeAsYouGo = 1;
    }
}