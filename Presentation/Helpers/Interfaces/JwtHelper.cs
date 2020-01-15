using AutoMapper;
using BusinessLogic.Common.Exceptions;
using BusinessLogic.Services.Interfaces;
using Common.Models;
using Common.Options;
using Common.Views.Authetication.Response;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using static Common.Enums.Enums;

namespace Presentation.Helpers.Interfaces
{
    public class JwtHelper : IJwtHelper
    {
        private readonly JwtOptions _jwtOptions;
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;


        public JwtHelper(IOptions<JwtOptions> jwtOptions, IAuthenticationService authenticationService, IMapper mapper)
        {
            _jwtOptions = jwtOptions.Value;
            _authenticationService = authenticationService;
            _mapper = mapper;
            
        }

        public ResponseGenerateJwtAuthenticationView GenerateJwtToken(ResponseGetUserItemView userModel)
        {

            string permissionsClaim = GeneratePermissionsClaim(userModel.Permissions);

            List<Claim> refreshClaims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, userModel.Id),
            };

            List<Claim> accessClaims = refreshClaims;

            accessClaims.AddRange(new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, userModel.UserName),
                new Claim(ClaimTypes.Role, userModel.Role.ToString()),
                new Claim(nameof(userModel.Permissions), permissionsClaim),
            });


            DateTime accessExpires = DateTime.Now.AddSeconds(Convert.ToDouble(_jwtOptions.JwtExpireMinutes));

            DateTime refreshExpires = DateTime.Now.AddDays(Convert.ToDouble(_jwtOptions.JwtExpireDays));

            JwtSecurityToken accesstToken = GenerateToken(accessClaims, accessExpires);

            JwtSecurityToken refreshToken = GenerateToken(refreshClaims, refreshExpires);

            var jwtModel = new ResponseGenerateJwtAuthenticationView();

            jwtModel.AccessToken = new JwtSecurityTokenHandler().WriteToken(accesstToken);
            jwtModel.RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshToken);
            jwtModel.FirstName = userModel.FirstName;
            jwtModel.LastName = userModel.LastName;
            jwtModel.Email = userModel.Email;

            return jwtModel;
        }

        private string GeneratePermissionsClaim(List<UsersPermissionsModel> permissions)
        {
            string res = string.Empty;

            foreach(var permission in permissions)
            {
                res += permission.Page.ToString()+":";
                res += nameof(permission.CanEdit) + "=" + permission.CanEdit.ToString() + ",";
                res += nameof(permission.CanView) + "=" + permission.CanView.ToString() + ";";
            }

            return res;
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

            string userId = refreshToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

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
            AppUser newUser = _authenticationService.GetUserWithPermissionsByIdAsync(user.Id).Result;

            user = _mapper.Map(newUser, user);
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
