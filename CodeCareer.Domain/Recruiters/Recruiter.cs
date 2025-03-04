﻿using CodeCareer.Posts;
using CodeCareer.Primitives;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Recruiters
{
    public class Recruiter : IdentityUser
    {
        public Recruiter(string address, string description, string name)
        {
            Address = address;
            Description = description;
            Name = name;
        }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Description { get; private set; }

        public List<Post> Posts { get; private set; } = new List<Post>();
    }
}
