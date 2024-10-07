using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MVC.CRUD.Interface.UtilityHelpers;

public class Utility
{
    public static void SetSecretAuthenticationKey(string secretAuthenticationKey)
    {
        SecretAuthenticationKey = secretAuthenticationKey;
    }

    public const string IssuerAudience = "liquidassets.co.za";
    public static string SecretAuthenticationKey { get; private set; }

    public static (string, DateTime) GenerateJwtToken(string userName, string role)
    {

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(SecretAuthenticationKey);
        var expires = DateTime.Now.AddMinutes(60);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = "liquidassets.co.za",
            Audience = "liquidassets.co.za",
            Subject = new ClaimsIdentity(new Claim[]
            {
                //new Claim(ClaimTypes.NameIdentifier, applicationId.ToString()),
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, role)
            }),

            Expires = expires,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return (tokenHandler.WriteToken(token), expires);
    }
}
