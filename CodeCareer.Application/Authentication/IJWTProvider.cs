using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.Authentication
{
    public interface IJWTProvider
    {
        string GenerateToken(IdentityUser user, IList<string> userRoles);
    }
}
