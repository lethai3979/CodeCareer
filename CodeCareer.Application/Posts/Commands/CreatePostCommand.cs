using Application.Abstraction;
using CodeCareer.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.Posts.Commands
{

    public sealed record CreatePostCommands(string title,string description, string RecruiterId,DateTime publishDate,DateTime expireDate) : ICommand<Result>;
}
