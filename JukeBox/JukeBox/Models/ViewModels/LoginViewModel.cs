using System.ComponentModel.DataAnnotations;

namespace JukeBox.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string UserName { get; set; }

        public bool IsAuthenticated { get; set; }


    }
}
