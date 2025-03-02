using CodeCareer.Application.Recruiters.Commands;
using CodeCareer.Application.UnitOfWork;
using CodeCareer.Domain.Interfaces;
using CodeCareer.Domain.Roles;
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
    public class CreateRecruiterCommandHandler : IRequestHandler<CreateRecruiterCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public  CreateRecruiterCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateRecruiterCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _unitOfWork.BeginTransactionAsync();
            var recruiter = new Recruiter(request.Name, request.Email);
            recruiter.UserName = request.Email;
            recruiter.Email = request.Email;
            try
            {
                var addUserResult = await _unitOfWork.UserRepository.Create(recruiter, request.Password);
                if (!addUserResult.Succeeded)
                {
                    return Result.FailureResult(Error.BadRequest(string.Join("; ", addUserResult.Errors.Select(e => e.Description))));
                }
                var addRoleToUserResult = await _unitOfWork.UserRepository.SetUserRole(recruiter, Role.Recruiter);
                if (!addRoleToUserResult.Succeeded)
                {
                    await transaction.RollbackAsync();
                    return Result.FailureResult(Error.BadRequest(string.Join("; ", addRoleToUserResult.Errors.Select(e => e.Description))));
                }
                return Result.SuccessResult();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return Result.FailureResult(Error.BadRequest(ex.Message));
            }

        }
    }
}
