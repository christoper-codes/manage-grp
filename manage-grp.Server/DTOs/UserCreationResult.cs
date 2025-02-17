using Microsoft.AspNetCore.Identity;
using manage_grp.Server.Models;

namespace manage_grp.Server.DTOs
{
    public class UserCreationResult
    {
        public User? User { get; set; }

        public IEnumerable<IdentityError>? Errors { get; set; } = new List<IdentityError>();
    }
}