using CodeCareer.Application.Recruiters.Commands;
using CodeCareer.Application.UnitOfWork;
using CodeCareer.Domain.Interfaces;
using CodeCareer.Domain.Shared;
using CodeCareer.Recruiters;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.Recruiters.Handlers
{
    public class CreateRecruitersHandler : IRequestHandler<CreateRecruitersCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public  CreateRecruitersHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateRecruitersCommand request, CancellationToken cancellationToken)
        {
            var recruiter = new Recruiter(request.Name, request.Email);
            recruiter.UserName = request.Email;
            recruiter.Email = request.Email;
            var result = await _unitOfWork.UserRepository.Create(recruiter, request.Password);
            if (!result.Succeeded)
            {
                return Result.FailureResult(Error.BadRequest(string.Join("; ", result.Errors.Select(e => e.Description))));
            }
            return Result.SuccessResult();
        }
    }
}
