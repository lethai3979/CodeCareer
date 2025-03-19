using CodeCareer.Application.Posts.Commands;
using CodeCareer.Application.UnitOfWork;
using CodeCareer.Domain.Shared;
using CodeCareer.Posts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.Posts.Handlers.CommandHandlers
{

    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeletePostCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.PostRepository.GetById(new Guid(request.Id));
            if (post is null)
                return Result.FailureResult(Error.NotFound("Post not found"));
            if (request.RequestBy != post.RecruiterId)
                return Result.FailureResult(Error.Unauthorized("You are not authorized to delete this post"));
            try
            {
                post.SoftDelete();
                _unitOfWork.PostRepository.Update(post);
                await _unitOfWork.SaveChangeAsync();
                return Result.SuccessResult();
            }
            catch (Exception ex)
            {

                return Result.FailureResult(Error.OperationFailed($"Failed to delete post: {ex.Message}"));

            }
        }
    }
}
