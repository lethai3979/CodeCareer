using Application.Abstraction;
using CodeCareer.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.Login
{
    public sealed record LoginCommand : ICommand<Result>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }    
    }
}
