using System;

namespace RequestMocker.Classes
{
    public class TokenGenerator
    {
        public string GenerateToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}