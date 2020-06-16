using Banking.Shared;
using System.Runtime.Serialization;
using Banking.Domain.CountryManagement;

namespace Banking.Domain.CityManagement
{
    [DataContract]
    public class City : Entity
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Country Country { get; set; }
        public City(string name)
        {
            Name = name;
        }
    }
}
