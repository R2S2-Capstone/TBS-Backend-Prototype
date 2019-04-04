using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TBS_Backend_Prototype.Models
{
    public class Dealer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a company name")]
        [DisplayName("Company name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = " Please enter an email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [DisplayName("Payment email")]
        public string CompanyPaymentEmail { get; set; }

        [Required(ErrorMessage = " Please enter an address")]
        [DisplayName("Company address")]
        public string CompanyAddress { get; set; }

        [Required(ErrorMessage = "Please enter a first name")]
        [DisplayName("Contact first name")]
        public string ContactFirstName { get; set; }

        [Required(ErrorMessage ="Please enter a last name")]
        [DisplayName("Contact last name")]
        public string ContactLastName { get; set; }

        [Required(ErrorMessage = "Please enter a phone number")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        [DisplayName("Contact phone number")]
        public string ContactPhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter an email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [DisplayName("Contact email")]
        public string ContactEmail { get; set; }
    }
}
