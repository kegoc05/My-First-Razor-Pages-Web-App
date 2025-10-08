using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace MyResumeSite.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public ContactFormModel ContactForm { get; set; } = new ContactFormModel();

        public string? SuccessMessage { get; set; }
        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostSendMessage()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Please correct the errors below.";
                return Page();
            }

            try
            {
                // Here you would typically send an email or save to database
                // For now, we'll just show a success message
                SuccessMessage = $"Thank you, {ContactForm.Name}! Your message has been received. I'll get back to you soon.";
                
                // Clear the form after successful submission
                ContactForm = new ContactFormModel();
                
                return Page();
            }
            catch (Exception)
            {
                ErrorMessage = "Sorry, there was an error sending your message. Please try again later.";
                return Page();
            }
        }
    }

    public class ContactFormModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [StringLength(1000, ErrorMessage = "Message cannot be longer than 1000 characters")]
        public string Message { get; set; } = string.Empty;
    }
}

