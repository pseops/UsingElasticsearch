using BusinessLogic.Common.Views.Response.User;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Presentation.Common.Models;
using Presentation.Common.Response.Views;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Presentation.Helpers.Interfaces
{
    public class JwtHelper : IJwtHelper
    {
        private readonly JwtOptionsModel _jwtOptions;

        public JwtHelper(IOptions<JwtOptionsModel> jwtOptions)
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

            var accessExpires = DateTime.Now.AddMinutes(Convert.ToDouble(_jwtOptions.JwtExpireMinutes));

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

    }
}
