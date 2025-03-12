using Application.Abstraction;
using CodeCareer.Domain.Shared;
using CodeCareer.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CodeCareer.Application.Posts.Commands
{
    public record UpdatePostCommand : ICommand<Result>
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required DateTime ExpireDate { get; set; }
        public string? RequestUserId { get; set; }

    }
}
