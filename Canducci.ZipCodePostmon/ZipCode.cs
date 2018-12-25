using System;
namespace Canducci.ZipCodePostmon
{
    public class ZipCode
    {
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public string Address { get; set; }
        public string CodePostal { get; set; }
        public CityInfo CityInfo { get; set; }
        public UfInfo UFInfo { get; set; }
    }

    public class UfInfo
    {
        public string Name { get; set; }
        public string Areakm2 { get; set; }
        public string CodeIbge { get; set; }        
    }

    public class CityInfo
    {
        public string AreaKm2 { get; set; }
        public string CodeIbge { get; set; }
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
