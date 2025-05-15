using System.ComponentModel.DataAnnotations;
using EasyStock.SharedKernel.Core.Base;
using MediatR;

namespace EasyStock.Application.Commands.User
{
    public class CreateEnterpriseCommand : IRequest<BaseResult<Guid>>
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Nome Fantasia é obrigatório")]
        public string FantasyName { get; set; }

        [Required(ErrorMessage = "Cnpj é obrigatório")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Cep é obrigatório")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Rua é obrigatório")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Número é obrigatório")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatório")]
        public string City { get; set; }

        [Required(ErrorMessage = "Estado é obrigatório")]
        public string State { get; set; }

        [Required(ErrorMessage = "País é obrigatório")]
        public string Country { get; set; }
    }
}