using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CodeCareer.Application.Posts.Commands
{
    public record UpdatePostCommand(String title,String description,DateTime PublishDate,DateTime ExpireDate);
}
