﻿using Application.Abstraction;
using CodeCareer.Domain.Shared;
using CodeCareer.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeCareer.Application.User.Appliers.Commands
{
    public sealed record ApplyPostCommand : ICommand<Result>
    {
        [JsonIgnore]
        public string? UserId { get; set; }
        public required PostId PostId { get; set; }
    }
}
