using Banking.Shared;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Banking.Domain.CityManagement;

namespace Banking.Domain.CountryManagement
{
    [DataContract]
    public class Country : Entity
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public ICollection<City> Cities { get; set; }

        public Country()
        {

        }

        public Country(string name)
        {
            Name = name;
        }
    }
}
