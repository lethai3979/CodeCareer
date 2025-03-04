using Application.Abstraction;
using CodeCareer.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeCareer.Application.User.Recruiters.Commands
{
    public record CreateRecruiterCommand : ICommand<Result>
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public string? Description { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    } 
}
