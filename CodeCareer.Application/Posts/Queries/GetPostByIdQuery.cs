﻿using Application.Abstraction.Queries;
using CodeCareer.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.Posts.Queries
{
    public sealed record GetPostByIdQuery(string Id) : IQuery<Result>;
}
