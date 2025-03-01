using CodeCareer.PostgreSQL.Authentication;
using Microsoft.Extensions.Options;

namespace CodeCareer.API.Authentication
{
    public class JWTOptionSetup : IConfigureOptions<JWTOption>
    {
        private readonly string _sectionName = "JWT";
        private readonly IConfiguration _config;

        public JWTOptionSetup(IConfiguration config)
        {
            _config = config;
        }

        public void Configure(JWTOption options)
        {
            _config.GetSection(_sectionName).Bind(options);
        }
    }
}
