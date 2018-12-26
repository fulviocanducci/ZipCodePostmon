using System.Runtime.Serialization;
namespace Canducci.ZipCodePostmon
{
    [DataContract]
    public sealed class ZipCode
    {
        [DataMember(Name = "complemento")]
        public string Complement { get; set; }

        [DataMember(Name = "bairro")]
        public string District { get; set; }

        [DataMember(Name = "cidade")]
        public string City { get; set; }

        [DataMember(Name = "estado")]
        public string UF { get; set; }

        [DataMember(Name = "logradouro")]
        public string Address { get; set; }

        [DataMember(Name = "cep")]
        public string CodePostal { get; set; }

        [DataMember(Name = "cidade_info")]
        public CityInfo CityInfo { get; set; }

        [DataMember(Name = "estado_info")]
        public UfInfo UFInfo { get; set; }        
    }
}
