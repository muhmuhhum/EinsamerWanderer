using System;
using System.Threading.Tasks;

namespace EinsamerWanderer.Auth
{
    public interface IJwtTokenHandler
    {
        string GenerateToken(Guid userId);

        bool IsValidToken(string token);
    }
}