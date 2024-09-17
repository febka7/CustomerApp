using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CustomerClient.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Email address is not valid.")]
        [DisplayName("Email Address")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Phone number is not valid.")]
        [DisplayName("Phone Number")]
        public string Phone { get; set; }
        [Required]
        [StringLength(maximumLength: 250, MinimumLength = 10)]
        public string Address { get; set; }
    }
}
