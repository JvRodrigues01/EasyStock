using EasyStock.SharedKernel.Core.Contracts;
using System.Net;

namespace EasyStock.SharedKernel.Core.Exceptions
{
    public class NotFoundException : Exception, IException
    {
        public int Code { get; set; } = (int)HttpStatusCode.NotFound;
        public override string Message { get; }
    }
}
