using CodeCareer.ApplierDetails;
using CodeCareer.Posts;
using CodeCareer.Primitives;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Appliers
{
    public class Applier : IdentityUser
    {
        public Applier(string description)
        {
            Description = description;
        }
        public string Description { get; private set; }

        public List<ApplierDetail> ApplierDetails { get; private set; } = new List<ApplierDetail>();
         
    }
}
