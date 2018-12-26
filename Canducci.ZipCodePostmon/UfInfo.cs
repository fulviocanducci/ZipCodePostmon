using System.Runtime.Serialization;
namespace Canducci.ZipCodePostmon
{
    [DataContract]
    public sealed class UfInfo: AbstractInfo
    {
        [DataMember(Name = "nome")]
        public string Name { get; set; }
    }

    //public class Rootobject
    //{
    //    public string complemento { get; set; }
    //    public string bairro { get; set; }
    //    public string cidade { get; set; }
    //    public string logradouro { get; set; }
    //    public Estado_Info estado_info { get; set; }
    //    public string cep { get; set; }
    //    public Cidade_Info cidade_info { get; set; }
    //    public string estado { get; set; }
    //}

    //public class Estado_Info
    //{
    //    public string area_km2 { get; set; }
    //    public string codigo_ibge { get; set; }
    //    public string nome { get; set; }
    //}

    //public class Cidade_Info
    //{
    //    public string area_km2 { get; set; }
    //    public string codigo_ibge { get; set; }
    //}
}
