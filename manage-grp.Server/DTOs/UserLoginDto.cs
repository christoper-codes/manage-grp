namespace manage_grp.Server.DTOs
{
    public class UserLoginDto
    {
        public string? UserNameOrEmail { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
