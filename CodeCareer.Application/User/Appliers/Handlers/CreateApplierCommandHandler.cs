using Application.Abstraction.Commands;
using CodeCareer.Application.UnitOfWork;
using CodeCareer.Application.User.Appliers.Commands;
using CodeCareer.Appliers;
using CodeCareer.Domain.Roles;
using CodeCareer.Domain.Shared;
using CodeCareer.Recruiters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.User.Appliers.Handlers
{
    internal class CreateApplierCommandHandler : ICommandHandler<CreateApplierCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateApplierCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateApplierCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _unitOfWork.BeginTransactionAsync();
            var applier = new Applier(request.description ?? string.Empty);
            applier.Email = request.Email;
            applier.UserName = request.Name;
            try
            {
                var addApplierResult = await _unitOfWork.UserRepository.Create(applier, request.Password);
                if (!addApplierResult.Succeeded)
                {

                    return Result.FailureResult(Error.BadRequest(string.Join("; ", addApplierResult.Errors.Select(e => e.Description))));
                }
                var addRoleToUserResult = await _unitOfWork.UserRepository.SetUserRole(applier, Role.Applier);
                if (!addRoleToUserResult.Succeeded)
                {
                    await transaction.RollbackAsync();
                    return Result.FailureResult(Error.BadRequest(string.Join("; ", addRoleToUserResult.Errors.Select(e => e.Description))));
                }
                await transaction.CommitAsync();
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
