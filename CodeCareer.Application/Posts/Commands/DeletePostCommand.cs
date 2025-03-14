using Application.Abstraction;
using CodeCareer.Domain.Shared;
using CodeCareer.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeCareer.Application.Posts.Commands
{
    public record DeletePostCommand : ICommand<Result>
    {
        public string Id { get; set; } = null!;
        public string RequestBy { get; set; } = string.Empty;
    }
}
