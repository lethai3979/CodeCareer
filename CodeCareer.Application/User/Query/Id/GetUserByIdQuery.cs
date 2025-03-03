using Application.Abstraction.Queries;
using CodeCareer.Application.UnitOfWork;
using CodeCareer.Domain.Shared;
using MediatR;
using System;
using System.Threading.Tasks;

namespace CodeCareer.Application.User.Query.Id
{
    public class GetUserByIdQuery : IQuery<Result>
    {
        public string Id { get; set; }
        public GetUserByIdQuery(string id) => Id = id;
    }

    
}