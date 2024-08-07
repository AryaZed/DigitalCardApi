using System.IdentityModel.Tokens.Jwt;

namespace CleanArc.Application.Models.Jwt
{
    public class AccessToken
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public int? user_id { get; set; }

        public AccessToken(JwtSecurityToken securityToken, string refreshToken = "", int? userId = null)
        {
            access_token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            token_type = "Bearer";
            expires_in = (int)(securityToken.ValidTo - DateTime.UtcNow).TotalSeconds;
            refresh_token = refreshToken;
            user_id = userId;
        }
    }
}