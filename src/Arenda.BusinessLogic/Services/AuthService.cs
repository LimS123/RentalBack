using Arenda.BusinessLogic.Contracts;
using Arenda.BusinessLogic.Contracts.Generators;
using Arenda.BusinessLogic.Contracts.Providers;
using Arenda.BusinessLogic.Models;
using Arenda.DataAccess.Contracts;
using Arenda.DataAccess.Contracts.Providers;
using Arenda.DataAccess.Contracts.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace Arenda.BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserProvider _userProvider;
        private readonly IHashProvider _hashProvider;
        private readonly IRefreshTokenProvider _refreshTokenProvider;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IDataContext _dataContext;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthService(
            IUserProvider userProvider,
            IHashProvider hashProvider,
            IRefreshTokenProvider refreshTokenProvider,
            IRefreshTokenRepository refreshTokenRepository,
            IDataContext dataContext,
            ITokenGenerator tokenGenerator)
        {
            _userProvider = userProvider;
            _hashProvider = hashProvider;
            _refreshTokenProvider = refreshTokenProvider;
            _refreshTokenRepository = refreshTokenRepository;
            _dataContext = dataContext;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<Token> Authenticate(string email, string password, CancellationToken token)
        {
            var hasAnyByEmail = await _userProvider.HasAnyByEmail(email, token);

            if (!hasAnyByEmail)
            {
                throw new ApplicationException("User doesn't exist");
            }

            var user = await _userProvider.GetByEmail(email, token);
            var passwordVerify = _hashProvider.Verify(password, user!.PasswordHash);

            if (!passwordVerify)
            {
                throw new SecurityTokenValidationException("Invalid password.");
            }

            var jwt = await _tokenGenerator.GenerateToken(user, token);

            return jwt;
        }

        public async Task<Token> Authenticate(string refreshToken, CancellationToken token)
        {
            var userToken = await _refreshTokenProvider.GetToken(refreshToken, token);

            if (userToken is null)
            {
                throw new SecurityTokenValidationException("Refresh token not found or expired.");
            }

            var hasAnyById = await _userProvider.HasAnyById(userToken.UserId, token);

            if (!hasAnyById)
            {
                throw new SecurityTokenValidationException("Associated user not found.");
            }

            var user = await _userProvider.GetById(userToken.UserId, token);

            _refreshTokenRepository.Delete(userToken);
            await _dataContext.SaveChanges(token);

            var jwt = await _tokenGenerator.GenerateToken(user!, token);

            return jwt;
        }
    }
}
