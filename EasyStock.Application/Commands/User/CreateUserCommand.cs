using System.ComponentModel.DataAnnotations;
using EasyStock.SharedKernel.Core.Base;
using MediatR;

namespace EasyStock.Application.Commands.User
{
    public class CreateUserCommand : IRequest<BaseResult<Guid>>
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Sobrenome é obrigatório")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Função é obrigatório")]
        public Domain.User.Enums.UserRoleEnum Role { get; set; }

        [Required(ErrorMessage = "Empresa é obrigatório")]
        public Guid EnterpriseId { get; set; }

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