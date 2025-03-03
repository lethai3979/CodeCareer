using Application.Abstraction.Queries;
using CodeCareer.Application.UnitOfWork;
using CodeCareer.Application.User.Query.email;
using CodeCareer.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.User.Query
{
    public class UserQueryHandler :

        IQueryHandler<GetUserByEmailQuery, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<Result> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.FindByEmail(request.Email);
            if (user == null)
            {
                return Result.FailureResult(Error.NotFound("Email not found"));
            }
            return Result<IdentityUser>.SuccessResult(user);
        }
    }
}
