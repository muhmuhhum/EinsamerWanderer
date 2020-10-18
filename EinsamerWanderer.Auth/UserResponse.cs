using System;

namespace EinsamerWanderer.Auth
{
    public class UserResponse
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string JwtToken { get; set; }
    }
}