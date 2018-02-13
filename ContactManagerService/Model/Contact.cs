using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ContactManagerService.Model
{
    [DataContract]
    public class Contact
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public Address Address { get; set; }

        internal static IList<Contact> GetFakeData()
        {
            IList<Contact> result = new List<Contact>();

            for(int i = 0; i < 10; i++)
            {
                result.Add(new Contact
                {
                    Id = i,
                    FirstName = Faker.Name.First(),
                    LastName = Faker.Name.Last(),
                    Email = Faker.Internet.Email(),
                    Address = new Address
                    {
                        Id = i,
                        City = Faker.Address.City(),
                        Street = Faker.Address.StreetName(),
                        ZipCode = Faker.Address.ZipCode()
                    }
                });
            }

            return result;
        }
    }
}
