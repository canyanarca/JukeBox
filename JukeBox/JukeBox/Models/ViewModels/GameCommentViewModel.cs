using JukeBox.Models.Entities;

namespace JukeBox.Models.ViewModels
{
    public class GameCommentViewModel
    {
        public Game Game { get; set; }
        public string UrlName { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
