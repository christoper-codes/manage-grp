using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace manage_grp.Server.DTOs
{
    public class JwtSecurityTokenDto
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public DateTime Expiration { get; set; }

        public IEnumerable<Claim> Claims { get; set; }

        public SigningCredentials SigningCredentials { get; set; }
    }
}
