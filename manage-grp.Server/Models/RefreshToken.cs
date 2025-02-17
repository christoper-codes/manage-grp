using System.Text.Json.Serialization;

namespace manage_grp.Server.Models
{
    public class RefreshToken
    {
        public int? Id { get; set; }

        public string Token { get; set; }

        public string UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }

        public DateTime Expiration { get; set; }

        public bool IsRevoked { get; set; } = false;
    }
}
