using Arenda.BusinessLogic.Contracts.Generators;
using Arenda.BusinessLogic.Contracts.Providers;
using Arenda.BusinessLogic.Models;
using Arenda.DataAccess.Contracts;
using Arenda.DataAccess.Contracts.Providers;
using Arenda.DataAccess.Contracts.Repositories;
using Arenda.DataAccess.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Arenda.BusinessLogic.Generators
{
    public class TokenGenerator : ITokenGenerator
    {
        private static readonly string _tokenType = "Bearer";

        private readonly IUserRolesProvider _userRolesProvider;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IDataContext _dataContext;
        private readonly JwtTokenOptions _jwtTokenOptions;
        private readonly RefreshTokenOptions _refreshTokenOptions;

        public TokenGenerator(
            IUserRolesProvider userRolesProvider,
            IDateTimeProvider dateTimeProvider,
            IRefreshTokenRepository refreshTokenRepository,
            IDataContext dataContext,
            IOptions<JwtTokenOptions> jwtTokenOptions,
            IOptions<RefreshTokenOptions> refreshTokenOptions)
        {
            _userRolesProvider = userRolesProvider;
            _dateTimeProvider = dateTimeProvider;
            _refreshTokenRepository = refreshTokenRepository;
            _dataContext = dataContext;
            _jwtTokenOptions = jwtTokenOptions.Value;
            _refreshTokenOptions = refreshTokenOptions.Value;
        }

        public async Task<Token> GenerateToken(DataAccess.Entities.User user, CancellationToken token)
        {
            var role = await _userRolesProvider.GetRoleByUserId(user.Id, token);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, RoleToString(role!.Type))
            };
            var issuedAtUtc = _dateTimeProvider.NowUtc;
            var expiresJwtAtUtc = issuedAtUtc.Add(_jwtTokenOptions.TokenLifetime);
            var expiresRefreshAtUtc = issuedAtUtc.Add(_refreshTokenOptions.TokenLifetime);
            var bytes = Encoding.ASCII.GetBytes(_jwtTokenOptions.EncryptionKey!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtTokenOptions.Issuer,
                NotBefore = issuedAtUtc,
                Subject = new ClaimsIdentity(claims),
                Expires = expiresJwtAtUtc,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(bytes), _jwtTokenOptions.SecurityAlgorithm)
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
            
            byte[] array = new byte[_refreshTokenOptions.SizeInBytes];

            using RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(array);
            var refreshToken = Convert.ToBase64String(array);
            var userRefreshToken = new UserRefreshToken()
            {
                UserId = user.Id,
                ExpiresAtUtc = expiresRefreshAtUtc,
                IssuedAtUtc = issuedAtUtc,
                Token = refreshToken
            };

            _refreshTokenRepository.Create(userRefreshToken);
            await _dataContext.SaveChanges(token);

            var jwt = new Token
            {
                AccessToken = jwtSecurityTokenHandler.WriteToken(jwtToken),
                RefreshToken = refreshToken,
                IssuedAtUtc = issuedAtUtc,
                JwtTokenExpiresAtUtc = expiresJwtAtUtc,
                RefreshTokenExpiresAtUtc = expiresRefreshAtUtc,
                TokenType = _tokenType
            };

            return jwt;
        }

        private string RoleToString(RoleType type) => type switch
        {
            RoleType.User => "User",
            RoleType.Landlord => "Landlord",
            RoleType.Administrator => "Administrator",
            RoleType.Unspecified => throw new ArgumentException(nameof(type), $"Not found role: {type}"),
            _ => throw new ArgumentOutOfRangeException(nameof(type), $"Not expected direction value: {type}"),
        };
    }
}
