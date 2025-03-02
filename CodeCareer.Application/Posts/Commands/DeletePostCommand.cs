using Application.Abstraction;
using CodeCareer.Domain.Shared;
using CodeCareer.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.Posts.Commands
{
    public record DeletePostCommand(PostId PostId):ICommand<Result>;
}
