namespace JukeBox.Models.Entities
{
    public class GameCategory
    {
        public Guid GameID { get; set; }

        public Guid CategoryID { get; set; }

        public Game Game { get; set; }
        public Category Category { get; set; }
    }
}
