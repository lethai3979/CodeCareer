using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Domain.Roles
{
    public static class Role
    {
        public const string Admin = "Admin";
        public const string Applier = "Applier";
        public const string Recruiter = "Recruiter";

        public static readonly List<string> AllRoles = new List<string>() { Admin, Applier, Recruiter };
    }
}
