using JukeBox.Models.Entities;

namespace JukeBox.Models.ViewModels
{
    public class GameCategoryViewModel
    {
        public Game Game { get; set; }
        public List<Category> Categories { get; set; }
    }
}
