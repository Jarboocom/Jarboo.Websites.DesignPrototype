using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
    public class ContactViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        public string Company { get; set; }

        public string Message { get; set; }

        public string Status { get; set; }

    }
}