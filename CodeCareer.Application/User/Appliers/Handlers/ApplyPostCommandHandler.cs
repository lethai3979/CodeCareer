using Application.Abstraction.Commands;
using CodeCareer.Application.UnitOfWork;
using CodeCareer.Application.User.Appliers.Commands;
using CodeCareer.ApplierDetails;
using CodeCareer.Domain.Shared;
using CodeCareer.Posts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.User.Appliers.Handlers
{
    public sealed class ApplyPostCommandHandler : ICommandHandler<ApplyPostCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplyPostCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ApplyPostCommand request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.PostRepository.GetById(request.PostId);
            if (post == null)
            {
                return Result.FailureResult(Error.NotFound("Post not exist"));
            }
            var postDetailLenght = await _unitOfWork.ApplierDetailRepository.GetAll();
            var postDetail = new ApplierDetail
            (
                Guid.NewGuid(),
                request.UserId,
                request.PostId
            );
            try
            {
                await _unitOfWork.ApplierDetailRepository.Add(postDetail);
                await _unitOfWork.SaveChangeAsync();
                return Result.SuccessResult();
            }
            catch (DbUpdateException dbEx)
            {
                return Result.FailureResult(Error.Conflict(dbEx.Message));
            }
            catch (Exception ex)
            {
                return Result.FailureResult(Error.OperationFailed(ex.Message));
            }
        }
    }
}
