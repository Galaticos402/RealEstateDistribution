using Core;
using Infrastructure.Exceptions;
using Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;
        private readonly IGenericRepository<User> _userRepository;
        public AuthService(IConfiguration configuration, IGenericRepository<User> userRepository, IServiceProvider serviceProvider)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _serviceProvider = serviceProvider;
        }

        public async Task<string> Authorize(string email, string password)
        {
            var user = _userRepository.Filter(x => x.Email == email && x.Password == password).FirstOrDefault();
            if (user != null)
            {
                return await GenerateToken(user);
            }

            throw new DBTransactionException("Cannot find the user", System.Net.HttpStatusCode.BadRequest);
        }

        private async Task<string> GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                //new Claim(ClaimTypes.NameIdentifier, model.MemberEmail),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim("Roles", user.Role)
            };
            var token = new JwtSecurityToken(_configuration.GetSection("Jwt:Issuer").Value, _configuration.GetSection("Jwt:Audience").Value, claims,
                       expires: DateTime.Now.AddMinutes(60),

                       signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public int? GetCurrentUserId(string authHeader)
        {
            if(authHeader == null) return null;
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = authHeader.Replace("Bearer ", "");
            var token = handler.ReadToken(jwtToken) as JwtSecurityToken;
            if(token == null)
            {
                return null;
            }
            var userIdObj = token.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub);
            if(userIdObj == null)
            {
                return null;
            }
            int userId = -1;
            int.TryParse(userIdObj.Value, out userId);

            return userId;
        }

        public string? GetCurrentUserRole(string authHeader)
        {
            if (authHeader == null) return null;
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = authHeader.Replace("Bearer ", "");
            var token = handler.ReadToken(jwtToken) as JwtSecurityToken;
            if (token == null)
            {
                return null;
            }
            var role = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            if (role == null)
            {
                return null;
            }

            return role.Value;
        }
    }
}
