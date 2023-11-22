using Microsoft.AspNetCore.Identity;

namespace JukeBox_API.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
