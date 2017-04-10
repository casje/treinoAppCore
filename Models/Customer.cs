using System.ComponentModel.DataAnnotations;

namespace treinoAppCore.Models
{
    public class Customer
    {
        public int Ident { get; set; }

        [Required, MaxLength(30)]
        [Display(Name = "First Name of the Customer")]        
        public string FirstName { get; set; }

        [Required, MaxLength(30)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, MaxLength(9)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail Address")]
        public string EmailAddress { get; set; }
    }
}