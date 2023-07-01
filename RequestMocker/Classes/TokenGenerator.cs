using System;

namespace RequestMocker.Classes
{
    /// <summary>
    /// Class responsible for generating tokens.
    /// </summary>
    public class TokenGenerator
    {
        /// <summary>
        /// Generates a unique token.
        /// </summary>
        /// <returns>
        /// A string representing a unique GUID.
        /// </returns>
        public string GenerateToken()
        {
            // Create and return a new GUID
            return Guid.NewGuid().ToString();
        }
    }
}
