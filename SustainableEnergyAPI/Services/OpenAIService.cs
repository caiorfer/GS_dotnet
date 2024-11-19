using Newtonsoft.Json;
using System.Text;

namespace SustainableEnergyAPI.Services
{
    public class OpenAIService
    {
        private readonly HttpClient _httpClient;

        public OpenAIService(IHttpClientFactory httpClientFactory)
        {
            // Recupera o cliente configurado para a OpenAI
            _httpClient = httpClientFactory.CreateClient("OpenAI");
        }

        public async Task<string> GetGPTResponse(string prompt)
        {
            var requestBody = new
            {
                model = "gpt-4",
                messages = new[]
                {
            new { role = "system", content = "You are a helpful assistant." },
            new { role = "user", content = prompt }
        }
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("chat/completions", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<OpenAIResponse>(responseContent);

                // Verifica se result e choices não são nulos
                if (result?.Choices != null && result.Choices.Count > 0)
                {
                    return result.Choices[0]!.Message!.Content!;
                }

                return "Error: No valid choices in the response.";
            }
                else
                {
                return $"Error: {response.StatusCode}";
                }
        }
    }
}
