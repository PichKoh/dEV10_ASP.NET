using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication10.Models
{
    public class Consultation
    {
        [StringLength(100, ErrorMessage = "Name length can't be more than 100.")]
        [Required(ErrorMessage = "Empty Name provided !")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100.")]
        [Required(ErrorMessage = "Empty Email provided!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Subject is required!")]
        [RegularExpression("^JS$|^C#$|^Java$|^Python$|^Основи$", ErrorMessage = "Didn't recognize subject!")]
        public string Subject { get; set; }


        [Remote("ValidateDateEqualOrGreater", HttpMethod = "Post", ErrorMessage = "Date isn't equal or greater than current date.")]
        [Required(ErrorMessage = "Empty Subject provided!")]
        public DateTime Date { get; set; }
    }
}
