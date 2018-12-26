using System.Runtime.Serialization;
namespace Canducci.ZipCodePostmon
{
    [DataContract]
    public abstract class AbstractInfo
    {
        [DataMember(Name = "area_km2")]        
        public string AreaKm2 { get; set; }

        [DataMember(Name = "codigo_ibge")]
        public int CodeIbge { get; set; }
    }
}
