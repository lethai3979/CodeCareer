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
    public record UpdatePostCommand(PostId PostId, string title, string description,DateTime PublishDate,DateTime ExpireDate):ICommand<Result>;
}
