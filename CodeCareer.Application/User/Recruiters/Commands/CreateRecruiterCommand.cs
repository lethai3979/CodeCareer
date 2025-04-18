﻿using Application.Abstraction;
using CodeCareer.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeCareer.Application.User.Recruiters.Commands
{
    public record CreateRecruiterCommand(string Name, string Email, string Password) : ICommand<Result>;
}
