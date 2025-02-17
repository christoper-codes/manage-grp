using System.Security.Claims;

namespace manage_grp.Server.DTOs
{
    public class TokenValidationResultDto
    {        
        public ClaimsPrincipal? ClaimsPrincipal { get; set; }

        public bool IsValid { get; set; }
    }
}
