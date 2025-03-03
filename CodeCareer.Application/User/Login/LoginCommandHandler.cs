using Application.Abstraction.Commands;
using CodeCareer.Application.Authentication;
using CodeCareer.Application.UnitOfWork;
using CodeCareer.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.User.Login
{
    internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJWTProvider _jwtProvider;

        public LoginCommandHandler(IUnitOfWork unitOfWork, IJWTProvider jwtProvider)
        {
            _unitOfWork = unitOfWork;
            _jwtProvider = jwtProvider;
        }

        public async Task<Result> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.FindByEmail(request.Email);
            if (user == null)
            {
                return Result.FailureResult(Error.NotFound("User not found"));
            }
            var isPasswordValid = await _unitOfWork.UserRepository.CheckPassword(user, request.Password);
            if (!isPasswordValid)
            {
                return Result.FailureResult(Error.BadRequest("Wrong email or password !"));
            }
            var userRoles = await _unitOfWork.UserRepository.GetAllUserRoles(user);
            var token = _jwtProvider.GenerateToken(user, userRoles);
            return Result<string>.SuccessResult(token);
        }
    }
}
