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
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloudService _cloudService;
        public CreatePostCommandHandler(IUnitOfWork unitOfWork, ICloudService cloudService)
        {
            _unitOfWork = unitOfWork;
            _cloudService = cloudService;
        }

        public async Task<Result> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var imageString = await _cloudService.UploadImageAsync(request.Image!);
                var post = new Post(Guid.NewGuid(), request.Title, request.Description, imageString, request.RecruiterId, request.ExpireDate);
                await _unitOfWork.PostRepository.Add(post);
                await _unitOfWork.SaveChangeAsync();
                return Result.SuccessResult();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }


}
