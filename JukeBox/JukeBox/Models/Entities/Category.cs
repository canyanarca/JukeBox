namespace JukeBox.Models.Entities
{
    public class Category : BaseEntity
    {

        public string Name = string.Empty;

        public ICollection<GameCategory> GameCategories { get; set; }


    }
}
