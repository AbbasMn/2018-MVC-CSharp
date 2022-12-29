using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Entertainment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Display(Name = "Type:")]
        public string Type { get; set; }

        [Display(Name = "Description:")]
        public string Description { get; set; }

        [Display(Name = "Continent:")]
        public string Continent { get; set; }

        [Display(Name = "Country:")]
        public string Country { get; set; }

        [Display(Name = "State:")]
        public string State { get; set; }


        [Display(Name = "City:")]
        public string City { get; set; }

        [Display(Name = "Date Added:")]
        public DateTime DateAdded { get; set; }        
    }
}