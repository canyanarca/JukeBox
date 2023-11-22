using JukeBox.Models.Entities;

namespace JukeBox.Models.Entities
{
    public class Comment : BaseEntity
    {
        public string CommentText { get; set; }
        
        public string UserName { get; set; } = string.Empty;

        public string UrlName { get; set; } 
    }
}
