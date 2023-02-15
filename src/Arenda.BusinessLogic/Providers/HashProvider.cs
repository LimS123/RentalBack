using Arenda.BusinessLogic.Contracts.Providers;

namespace Arenda.BusinessLogic.Providers
{
    public class BCryptHashProvider : IHashProvider
    {
        public string Hash(string value)
        {
            return BCrypt.Net.BCrypt.HashPassword(value);
        }

        public bool Verify(string value, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(value, hash);
        }
    }
}
