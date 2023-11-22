using System;
using System.Net.Http;

namespace ScreenMatch.Service
{
    public class ConsumoAPI
    {
        private readonly HttpClient client = new HttpClient();

        public string ObterDados(string endereco)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync(new Uri(endereco)).Result;

                // Verifica se a requisição foi bem-sucedida
                response.EnsureSuccessStatusCode();

                // Lê o conteúdo da resposta como string
                string json = response.Content.ReadAsStringAsync().Result;

                return json;
            }
            catch (HttpRequestException e)
            {
                // Trata exceções relacionadas à requisição HTTP
                throw new InvalidOperationException("Erro ao fazer a requisição HTTP.", e);
            }
        }
    }
}
