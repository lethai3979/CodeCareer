using Application.Abstraction.Commands;
using CodeCareer.Application.Abstraction;
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
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloudService _cloudService;
        public UpdatePostCommandHandler(IUnitOfWork unitOfWork, ICloudService cloudService)
        {
            _unitOfWork = unitOfWork;
            _cloudService = cloudService;
        }

        public async Task<Result> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.PostRepository.GetById(new Guid(request.Id));
            if (post == null)
            {
                return Result.FailureResult(Error.NotFound("Post not found"));
            }
            if (post.PublishDate >= request.ExpireDate)
            {
                return Result.FailureResult(Error.BadRequest("Publish date must be before Expire date."));
            }
            if (request.RequestUserId != post.RecruiterId)
            {
                return Result.FailureResult(Error.Unauthorized("Unauthorize"));
            }
            try
            {
                var imageUrl = await _cloudService.UploadImageAsync(request.Image!);
                post.Update(request.Title, request.Description, request.ExpireDate, imageUrl);
                _unitOfWork.PostRepository.Update(post);
                await _unitOfWork.SaveChangeAsync();
                return Result.SuccessResult();
            }
            catch (Exception ex)
            {
                return Result.FailureResult(Error.OperationFailed($"Failed to update post: {ex.Message}"));
            }
        }
    }
}
