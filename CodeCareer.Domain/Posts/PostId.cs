using CodeCareer.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Posts
{
    public record PostId(int value) : EntityId(value);
}
