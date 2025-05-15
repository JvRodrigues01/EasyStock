using EasyStock.Domain.Enterprise.Entities;
using EasyStock.Domain.User.Enums;
using EasyStock.SharedKernel.Core.Base;

namespace EasyStock.Domain.User.Entities
{
    public class User : EntityBase
    {
        public User(string firstName, string lastName, string email, string password,
            string phoneNumber, UserRoleEnum role, Guid enterpriseId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Role = role;
            EnterpriseId = enterpriseId;

            SetNewEntity();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string PhoneNumber { get; private set; }
        public UserRoleEnum Role { get; private set; }
        public Guid EnterpriseId { get; private set; }
        public Enterprise.Entities.Enterprise Enterprise { get; private set; }
        public Guid AddressId { get; private set; }
        public Address.Entities.Address Address { get; private set; }

        public void UpdatePasswordHash(string newPasswordHash)
        {
            Password = newPasswordHash;
        }
        public void SetAddress(Address.Entities.Address address)
        {
            Address = address;
            AddressId = address.Id;
        }
        public void SetEnterprise(Enterprise.Entities.Enterprise enterprise)
        {
            Enterprise = enterprise;
            EnterpriseId = enterprise.Id;
        }
    }
}
