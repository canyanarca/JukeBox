using Microsoft.AspNetCore.Identity;

namespace JukeBox.Models.Entities
{
    public class User : IdentityUser
    {

        public  Guid Id { get; set; }
        public override string UserName { get; set; }

        public string UserEmail { get; set; }

        public string UserPassword { get; set; }

        public ICollection<Game> Games { get; set; }

        public ICollection<Comment> Comments { get; set; }



    }
}
