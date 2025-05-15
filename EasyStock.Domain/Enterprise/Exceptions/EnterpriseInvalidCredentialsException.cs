using EasyStock.SharedKernel.Core.Exceptions;

namespace EasyStock.Domain.User.Exceptions
{
    public class EnterpriseInvalidCredentialsException : AuthoritativeException
    {
        public override string Message { get; } =
            "Credenciais inválidas";

        public EnterpriseInvalidCredentialsException(string message)
        {
            Message = message;
        }
    }
}
