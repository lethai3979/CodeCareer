using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.PostgreSQL.Authentication
{
    public class JWTOption
    {
        public required string Issuer { get; set; }
        public required string Audience{ get; set; }
        public required string SecretKey { get; set; }

    }
}
