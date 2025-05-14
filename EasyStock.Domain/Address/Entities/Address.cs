using EasyStock.SharedKernel.Core.Base;

namespace EasyStock.Domain.Address.Entities
{
    public class Address : EntityBase
    {
        public Address()
        {
            SetNewEntity();
        }

        public string ZipCode { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public Guid? UserId { get; private set; }
        public User.Entities.User User { get; private set; }
        public Guid? EnterpriseId { get; private set; }
        public Enterprise.Entities.Enterprise Enterprise { get; private set; }
    }
}
