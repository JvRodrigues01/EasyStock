using EasyStock.Domain.Address.Entities;
using EasyStock.Domain.Enterprise.Repositories;
using EasyStock.Domain.User.Exceptions;
using EasyStock.SharedKernel.Core.Base;
using MediatR;

namespace EasyStock.Application.Commands.User
{
    public class CreateEnterpriseCommandHandler : IRequestHandler<CreateEnterpriseCommand, BaseResult<Guid>>
    {
        private readonly IEnterpriseRepository _enterpriseRepository;
        public CreateEnterpriseCommandHandler(IEnterpriseRepository enterpriseRepository)
        {
            _enterpriseRepository = enterpriseRepository;
        }

        public async Task<BaseResult<Guid>> Handle(CreateEnterpriseCommand request, CancellationToken cancellationToken)
        {
            var existingEnterprise = await _enterpriseRepository.GetByEmailAsync(request.Email);
            if (existingEnterprise is not null)
                throw new EnterpriseInvalidCredentialsException("Este e-mail já está em uso");

            var enterprise = new Domain.Enterprise.Entities.Enterprise(
                request.CompanyName,
                request.FantasyName,
                request.Cnpj,
                request.Email,
                request.PhoneNumber
            );

            var address = new Address(
                request.ZipCode,
                request.Street,
                request.Number,
                request.Neighborhood,
                request.City,
                request.State,
                request.Country
            );

            enterprise.SetAddress(address);

            await _enterpriseRepository.AddAsync(enterprise);

            return new BaseResult<Guid>(enterprise.Id);
        }
    }
}
