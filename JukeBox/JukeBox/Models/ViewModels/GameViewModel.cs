using System.ComponentModel.DataAnnotations;

namespace JukeBox.Models.ViewModels
{
    public class GameViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string Description { get; set; }

        public string? Image {  get; set; }


    }
}
