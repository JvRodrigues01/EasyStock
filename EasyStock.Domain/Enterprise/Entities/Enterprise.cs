using EasyStock.SharedKernel.Core.Base;

namespace EasyStock.Domain.Enterprise.Entities
{
    public class Enterprise : EntityBase
    {
        public Enterprise(string companyName, string fantasyName,
            string cnpj, string email, string phoneNumber) 
        {
            CompanyName = companyName;
            FantasyName = fantasyName;
            Cnpj = cnpj;
            Email = email;
            PhoneNumber = phoneNumber;

            SetNewEntity();
        }

        public string CompanyName { get; private set; }
        public string FantasyName { get; private set; }
        public string Cnpj { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public Guid AddressId { get; private set; }
        public Address.Entities.Address Address { get; private set; }
        public IList<User.Entities.User> Users { get; private set; }

        public void SetAddress(Address.Entities.Address address)
        {
            Address = address;
            AddressId = address.Id;
        }
    }
}
