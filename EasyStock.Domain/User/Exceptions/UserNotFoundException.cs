using EasyStock.SharedKernel.Core.Exceptions;

namespace EasyStock.Domain.User.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public override string Message { get; } =
            "Usuário não encontrado";
    }
}
