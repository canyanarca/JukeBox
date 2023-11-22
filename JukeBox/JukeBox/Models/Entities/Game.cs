namespace JukeBox.Models.Entities
{
    public class Game : BaseEntity
    {
        public string Name = string.Empty; 
        
        public string Description = string.Empty;

        public string Image = string.Empty;

        public string UrlName = string.Empty;

        public int Price { get; set; }

        public Guid UserID { get; set; }
        
        public User User { get; set; } 
        
        public ICollection<GameCategory> GameCategories { get; set; }


        public ICollection<Comment> Comments { get; set; }





    }
}
