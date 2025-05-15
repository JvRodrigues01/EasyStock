using System.ComponentModel.DataAnnotations;
using EasyStock.SharedKernel.Core.Base;
using MediatR;

namespace EasyStock.Application.Commands.Auth
{
    public class AuthCommand : IRequest<BaseResult<string>>
    {
        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório")]
        public string Password { get; set; }
    }
}
