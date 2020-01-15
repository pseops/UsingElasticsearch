using BusinessLogic.Common.Exceptions;
using Common.Options;
using Common.Views.Authetication.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Common.Enums.Enums;

namespace Presentation.Helpers.Interfaces
{
    public class JwtHelper : IJwtHelper
    {
        private readonly JwtOptions _jwtOptions;

        public JwtHelper(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        public ResponseGenerateJwtAuthenticationView GenerateJwtToken(ResponseGetUserItemView userModel)
        {

            var refreshClaims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, userModel.Id),
            };

            var accessClaims = refreshClaims;

            accessClaims.AddRange(new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, userModel.UserName),
                new Claim(ClaimTypes.Role, userModel.Role.ToString()),
            });

            var accessExpires = DateTime.Now.AddSeconds(Convert.ToDouble(_jwtOptions.JwtExpireMinutes));

            var refreshExpires = DateTime.Now.AddDays(Convert.ToDouble(_jwtOptions.JwtExpireDays));

            var accesstToken = GenerateToken(accessClaims, accessExpires);

            var refreshToken = GenerateToken(refreshClaims, refreshExpires);

            var jwtModel = new ResponseGenerateJwtAuthenticationView();

            jwtModel.AccessToken = new JwtSecurityTokenHandler().WriteToken(accesstToken);
            jwtModel.RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshToken);
            jwtModel.FirstName = userModel.FirstName;
            jwtModel.LastName = userModel.LastName;
            jwtModel.Email = userModel.Email;

            return jwtModel;
        }

        private JwtSecurityToken GenerateToken(List<Claim> claims, DateTime expire)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.JwtKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _jwtOptions.JwtIssuer,
                _jwtOptions.JwtIssuer,
                claims,
                expires: expire,
                signingCredentials: creds
            );

            return token;
        }

        public string CheckTokenValidation(ResponseGenerateJwtAuthenticationView model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.RefreshToken))
            {
                return string.Empty;
            }

            var refreshToken = new JwtSecurityTokenHandler().ReadJwtToken(model.RefreshToken);

            var userId = refreshToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (refreshToken.ValidTo <= DateTime.UtcNow)
            {
                return string.Empty;
            }

            var user = new ResponseGetUserItemView();

            return userId;
        }

        public ResponseGenerateJwtAuthenticationView RefreshToken(ResponseGenerateJwtAuthenticationView model)
        {
            string encodedRefreshToken = model.RefreshToken;

            JwtSecurityToken refreshToken = new JwtSecurityTokenHandler().ReadJwtToken(encodedRefreshToken);

            if (refreshToken.ValidFrom >= DateTime.UtcNow || refreshToken.ValidTo <= DateTime.UtcNow)
            {
                throw new ProjectException(StatusCodes.Status401Unauthorized, "refresh token inValid");
            }

            ResponseGetUserItemView user = GetUserFromClaims(refreshToken);  
            

            ResponseGenerateJwtAuthenticationView jwtResponse = GenerateJwtToken(user);

            return jwtResponse;
        }
        private ResponseGetUserItemView GetUserFromClaims(JwtSecurityToken refreshToken)
        {
            ResponseGetUserItemView user = new ResponseGetUserItemView();

            user.Id = refreshToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            user.Role = (UserRole)Enum.Parse(typeof(UserRole), refreshToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value);
            user.UserName = refreshToken.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub)?.Value;

            return user;
        }
    }
}
