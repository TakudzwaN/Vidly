using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribed { get; set; }

        [Display(Name = "Date of Birth")]
        [MinMemberAge]
        public DateTime? Birthdate { get; set; }   
        
        //Navigation Properties

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Types")]
        public byte MembershipTypeId { get; set; }  
    }
}