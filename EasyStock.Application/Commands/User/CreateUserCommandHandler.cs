using EasyStock.Domain.User.Exceptions;
using EasyStock.Domain.User.Repositories;
using EasyStock.SharedKernel.Core.Base;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EasyStock.Application.Commands.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseResult<Guid>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<Domain.User.Entities.User> _passwordHasher;

        public CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher<Domain.User.Entities.User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<BaseResult<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
                throw new UserInvalidCredentialsException("Este e-mail já está em uso");

            var user = new Domain.User.Entities.User(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password,
                request.PhoneNumber,
                Domain.User.Enums.UserRoleEnum.Collaborator,
                request.EnterpriseId
            );

            var address = new Domain.Address.Entities.Address(
                request.ZipCode,
                request.Street,
                request.Number,
                request.Neighborhood,
                request.City,
                request.State,
                request.Country
            );

            user.SetAddress(address);

            var hashedPassword = _passwordHasher.HashPassword(user, request.Password);
            user.UpdatePasswordHash(hashedPassword);

            await _userRepository.AddAsync(user);

            return new BaseResult<Guid>(user.Id);
        }
    }
}
