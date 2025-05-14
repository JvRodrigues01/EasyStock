using EasyStock.SharedKernel.Core.Base;

namespace EasyStock.Domain.Enterprise.Entities
{
    public class Enterprise : EntityBase
    {
        public Enterprise() 
        {
            SetNewEntity();
        }

        public string CompanyName { get; private set; }
        public string FantasyName { get; private set; }
        public string Cnpj { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumer { get; private set; }
        public Guid AddressId { get; private set; }
        public Address.Entities.Address Address { get; private set; }
        public IList<User.Entities.User> Users { get; private set; }
    }
}
