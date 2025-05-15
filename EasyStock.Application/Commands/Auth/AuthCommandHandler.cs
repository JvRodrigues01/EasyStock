using EasyStock.Domain.Jwt.Services;
using EasyStock.Domain.User.Exceptions;
using EasyStock.Domain.User.Repositories;
using EasyStock.SharedKernel.Core.Base;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EasyStock.Application.Commands.Auth
{
    public class AuthCommandHandler : IRequestHandler<AuthCommand, BaseResult<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<Domain.User.Entities.User> _passwordHasher;
        private readonly JwtService _jwtTokenService;

        public AuthCommandHandler(IUserRepository userRepository,
            IPasswordHasher<Domain.User.Entities.User> passwordHasher,
            JwtService jwtTokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<BaseResult<string>> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user is null)
                throw new UserNotFoundException();

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);
            if (result == PasswordVerificationResult.Failed)
                throw new UserInvalidCredentialsException("Credenciais inválidas");

            var token = _jwtTokenService.GenerateToken(user);

            return new BaseResult<string>(token);
        }
    }
}
