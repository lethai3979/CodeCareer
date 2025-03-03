using Application.Abstraction;
using CodeCareer.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.Appliers
{
    public sealed record CreateApplierCommand : ICommand<Result>
    {
        public required string Name { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public string? description { get; set; }
    }
}
