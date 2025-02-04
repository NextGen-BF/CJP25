using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace NextGen_BM_BE_API{

    public class TokenGenerator{
        public string GenerateToken(string email){
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("ThisIsASecretKeyThatIsAtLeast16BytesLong!"); // Use appsettings instead
            var claims = new List<Claim>() {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Email, email)
            };

            var tokenDescriptor = new SecurityTokenDescriptor{
                Subject=new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                Issuer = "http://localhost:5204",
                Audience = "http://localhost:5204",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}