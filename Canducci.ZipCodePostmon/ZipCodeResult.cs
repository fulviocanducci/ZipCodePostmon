using Canducci.ZipCodePostmon.Internals;
using System.IO;
using System.Runtime.Serialization.Json;
namespace Canducci.ZipCodePostmon
{
    public sealed class ZipCodeResult
    {
        internal ZipCodeRequest ZipCodeRequest { get; set; }

        public ZipCodeResult() => ZipCodeRequest = ZipCodeRequest.Create();
        public static ZipCodeResult Create() => new ZipCodeResult();

#if NET40 || NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NET472 || NETSTANDARD2_0        
        public ZipCode Find(ZipCodeNumber number)
        {            
            Stream stream = ZipCodeRequest.GetStream((string)number);
            return GetJsonStreamSerializerToZipCode(stream);
        }
#endif
#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NET472 || NETSTANDARD1_1 || NETSTANDARD1_3 || NETSTANDARD1_4 || NETSTANDARD1_5 || NETSTANDARD1_6 || NETSTANDARD2_0
        public async System.Threading.Tasks.Task<ZipCode> FindAsync(ZipCodeNumber number)
        {
            Stream stream = await ZipCodeRequest.GetStreamAsync((string)number);
            return GetJsonStreamSerializerToZipCode(stream);
        }
#endif
        private ZipCode GetJsonStreamSerializerToZipCode(Stream stream)
        {
            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(ZipCode));            
            return (ZipCode)dataContractJsonSerializer.ReadObject(stream);
        }        
    }

}
