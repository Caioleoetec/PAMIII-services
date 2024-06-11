using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using ExemploHTTP.Models;
using System.Text.Json;
using ThreadNetwork;
using System.Diagnostics;

namespace ExemploHTTP.Services
{
    public class RestService
    {
        private HttpClient client;
        private Post post;
        private List<Post> posts;
        private JsonSerializerOptions _serializerOptions;

        RestService()
        {
            client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions{
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase, //fala que precisa ser em formato CamelCase
                WriteIndented = true //fala que tem que identar
            };
        }
        //Task => a forma que o maui usa para representar uma função async
        public async Task<List<Post>> getPostsAsync() // async => quando um processo pode "esperar" outro acontecer
        {
            Uri uri = new Uri("https://jsonplaceholder.typicode.com/posts");// uri pega a parte constate do URL ("192.0.0.1"/algo)
            try
            {
                //await => fala quem precisa esperar algo ou a requisisão (uma função async)
                HttpResponseMessage response = await client.GetAsync(uri); //response => representa a resposta (contem muita coisa e a nossa lista) do cliente app (url)
                if (response.IsSuccessStatusCode) //verifica se a resposta foi um sucesso
                {
                    string content = await response.Content.ReadAsStringAsync(); //transforma em string
                    posts = JsonSerializer.Deserialize<List<Post>>(content, _serializerOptions);//deserializa (enterder o que é aquele elemento e transformar em outro), neste caso transformar json em List<Post>, que é o
                                                                                                //serializerOptions => faz a identação das linhas
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return posts;
        }
    }
}
