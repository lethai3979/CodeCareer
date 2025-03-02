using Application.Abstraction;
using CodeCareer.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.Posts.Commands
{

    public sealed record CreatePostCommand : ICommand<Result>
    {
        public required string Title { get; set; } 
        public required string Description { get; set; }
        public required string RecruiterId { get; set; }
        public required DateTime PublishDate { get; set; }
        public required DateTime ExpireDate { get; set; }
    }
}
