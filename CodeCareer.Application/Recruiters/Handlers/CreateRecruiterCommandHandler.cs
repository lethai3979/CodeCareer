using CodeCareer.Application.Recruiters.Commands;
using CodeCareer.Application.UnitOfWork;
using CodeCareer.Domain.Roles;
using CodeCareer.Domain.Shared;
using CodeCareer.Recruiters;
using MediatR;

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
