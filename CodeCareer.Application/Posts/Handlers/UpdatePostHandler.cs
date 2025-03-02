﻿using Application.Abstraction.Commands;
using CodeCareer.Application.Posts.Commands;
using CodeCareer.Application.UnitOfWork;
using CodeCareer.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.Posts.Handlers
{
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePostHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.PostRepository.GetById(request.PostId);
            if (post == null)
                return Result.FailureResult(Error.NotFound("Post not found"));
            if (request.PublishDate >= request.ExpireDate)
            {
                return Result.FailureResult(Error.BadRequest("Publish date must be before Expire date."));
            }
            if (request.PublishDate >= request.ExpireDate)
            {
                return Result.FailureResult(Error.BadRequest("Publish date must be before Expire date."));
            }

            try
            {

                post.Update(request.title, request.description, request.PublishDate, request.ExpireDate);

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
