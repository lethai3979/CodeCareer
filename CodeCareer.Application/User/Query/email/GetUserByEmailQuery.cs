using Application.Abstraction.Queries;
using CodeCareer.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.User.Query.email
{
    public class GetUserByEmailQuery : IQuery<Result>
    {
        public string Email { get; set; }
        public GetUserByEmailQuery(string email) => Email = email;
    }
}
