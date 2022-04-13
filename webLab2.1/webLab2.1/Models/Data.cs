using System.ComponentModel.DataAnnotations;

namespace webLab2._1.Models
{
    public class Data
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Day { get; set; }
        [Required]
        public string Month { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ComparePassword { get; set; }
        public bool Remeber { get; set; }
        public int Code { get { return 7423; } }
    }
}
