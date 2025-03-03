using Application.Abstraction.Queries;
using CodeCareer.Application.UnitOfWork;
using CodeCareer.Application.User.Query.Id;
using CodeCareer.Domain.Shared;
using CodeCareer.Posts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.User.Query
{
    public class GetUserByIdHandler :
        IQueryHandler<GetUserByIdQuery, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.FindById(request.Id);
            if (user == null)
            {
                return Result.FailureResult(Error.NotFound("User not found"));
            }
            return Result<IdentityUser>.SuccessResult(user);
        }


    }
}
