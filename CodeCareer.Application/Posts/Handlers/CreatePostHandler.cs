using CodeCareer.Application.Posts.Commands;
using CodeCareer.Application.UnitOfWork;
using CodeCareer.Domain.Shared;
using CodeCareer.Posts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.Posts.Handlers
{
    public class CreatePostHandler : IRequestHandler<CreatePostCommands, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreatePostHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreatePostCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var lengthPost = await _unitOfWork.PostRepository.GetAll();
                var post = new Post(new PostId(lengthPost.Count + 1), request.title, request.RecruiterId, request.description, request.publishDate, request.expireDate);
                await _unitOfWork.PostRepository.Add(post);
                return Result.SuccessResult();
            }
            catch (DbUpdateException dbEx)
            {
               return Result.FailureResult(Error.BadRequest(dbEx.Message));
            }
            catch (Exception ex)
            {
                return Result.FailureResult(Error.OperationFailed(ex.Message));
            }
        }
    }
    

}
