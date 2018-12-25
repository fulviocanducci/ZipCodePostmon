using System.IO;
using System.Net;
namespace Canducci.ZipCodePostmon.Internals
{
    internal class ZipCodeRequest
    {
        private const string Url = "http://api.postmon.com.br/v1/cep/";
        private HttpWebRequest ClientRequest { get; set; }

#if NET40 || NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NET472 || NETSTANDARD2_0
        public string GetJson(string number)
        {
            ClientRequest = (HttpWebRequest)WebRequest.Create(GetUrlRender(number));            
            HttpWebResponse ClientResponse = (HttpWebResponse)ClientRequest.GetResponse();
            return GetStreamToString(ClientResponse.GetResponseStream());
        }
#endif

#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NET472 || NETSTANDARD1_1 || NETSTANDARD1_3 || NETSTANDARD1_4 || NETSTANDARD1_5 || NETSTANDARD1_6 || NETSTANDARD2_0
        public async System.Threading.Tasks.Task<string> GetJsonAsync(string number)
        {
            ClientRequest = (HttpWebRequest)WebRequest.Create(GetUrlRender(number));            
            HttpWebResponse ClientResponse = (HttpWebResponse)await ClientRequest.GetResponseAsync();
            return GetStreamToString(ClientResponse.GetResponseStream());
        }
#endif
        private string GetUrlRender(string number)
            => string.Format("{0}{1}", Url, number);

        private string GetStreamToString(Stream stream)
        {
            using (StreamReader StrReader = new StreamReader(stream, System.Text.Encoding.UTF8))
            {
                return StrReader.ReadToEnd();
            }
        }

        public static ZipCodeRequest Create() 
            => new ZipCodeRequest();
    }
}
