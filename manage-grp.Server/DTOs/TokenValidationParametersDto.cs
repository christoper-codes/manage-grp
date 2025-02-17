using Microsoft.IdentityModel.Tokens;

namespace manage_grp.Server.DTOs
{
    public class TokenValidationParametersDto
    {
        public bool ValidateIssuer { get; set; }

        public bool ValidateAudience { get; set; }

        public string ValidAudience { get; set; }

        public string ValidIssuer { get; set; }

        public  bool ValidateLifetime { get; set; }

        public TimeSpan ClockSkew { get; set; }

        public SymmetricSecurityKey IssuerSigningKey { get; set; }
    }
}
