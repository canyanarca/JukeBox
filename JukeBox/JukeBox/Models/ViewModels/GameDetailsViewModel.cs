using JukeBox.Models.Entities;

namespace JukeBox.Models.ViewModels
{
    public class GameDetailsViewModel
    {
        public Game CurrentGame { get; set; }
        public List<Game> RelatedGames { get; set; }
    }
}
