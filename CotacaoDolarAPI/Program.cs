using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace CotacaoDolarAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = string.Empty;

            HttpClient cliente = new HttpClient();

            Console.WriteLine("INFORME A DATA NO FORMATO MM-DD-YYYY");
            data = Console.ReadLine();

            HttpResponseMessage retornoHttp;

            retornoHttp = cliente.GetAsync($"https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/CotacaoDolarDia(dataCotacao=@dataCotacao)?@dataCotacao=%27{data}%27&$top=100&$format=json").Result;

            string respostaString = retornoHttp.Content.ReadAsStringAsync().Result;
            DadosCotacao dados = JsonConvert.DeserializeObject<DadosCotacao>(respostaString);

            Console.WriteLine($" COTAÇÃO INICIO :{dados.value[0].cotacaoCompra}");
            Console.WriteLine($" COTAÇÃO FIM :{dados.value[0].cotacaoVenda}");
            Console.WriteLine($"DATA DA COTAÇÃO :{dados.value[0].dataHoraCotacao}");


            Console.ReadKey();


            
        }
    }
}
