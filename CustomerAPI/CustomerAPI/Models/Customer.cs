using System.ComponentModel.DataAnnotations;

namespace CustomerAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Email address is not valid.")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Phone number is not valid.")]
        public string Phone { get; set; }
        [Required]
        [StringLength(maximumLength: 250, MinimumLength = 10)]
        public string Address { get; set; }
    }
}
