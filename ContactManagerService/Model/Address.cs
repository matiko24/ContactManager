using System.Runtime.Serialization;

namespace ContactManagerService.Model
{
    [DataContract]
    public class Address
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string  Street { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string ZipCode { get; set; }

    }
}