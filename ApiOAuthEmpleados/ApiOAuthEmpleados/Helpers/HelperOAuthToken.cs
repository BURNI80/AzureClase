using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiOAuthEmpleados.Helpers
{
    public class HelperOAuthToken
    {

        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }

        public HelperOAuthToken(IConfiguration config)
        {
            this.Issuer = config.GetValue<string>("ApiOauth:Issuer");
            this.Audience = config.GetValue<string>("ApiOauth:Audience");
            this.SecretKey = config.GetValue<string>("ApiOauth:SecretKey");
        }


        public SymmetricSecurityKey GetKeyToken()
        {
            byte[] data = Encoding.UTF8.GetBytes(this.SecretKey);
            return new SymmetricSecurityKey(data);
        }


        public Action<JwtBearerOptions> GetJwtOptions()
        {
            Action<JwtBearerOptions> options =
            new Action<JwtBearerOptions>(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Issuer,
                    ValidAudience = Audience,
                    IssuerSigningKey = GetKeyToken()
                };
            });
            return options;
        }


        public Action<AuthenticationOptions> GetAuthenticationOptions()
        {
            Action<AuthenticationOptions> options = new Action<AuthenticationOptions>(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });
            return options;
        }

    }
}
