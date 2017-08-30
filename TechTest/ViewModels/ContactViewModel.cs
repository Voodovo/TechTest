using System.ComponentModel.DataAnnotations;


namespace TechTest.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Email address is required")]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Telephone number is required")]
        public string TelephoneNumber { get; set; }
    }
}