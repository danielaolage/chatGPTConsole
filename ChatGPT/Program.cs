using Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            ChatGptRequest chatGptRequest = YourRequest();
            StringContent jsonContent = CreateJsonContent(chatGptRequest, jsonSerializerOptions);
            string yourResponse = await YourResponseAsync(jsonContent, jsonSerializerOptions);
            Console.WriteLine(yourResponse);
            Console.ReadLine();
        }

        private static ChatGptRequest YourRequest()
        {
            Console.WriteLine("Olá, sou o ChatGPT na versão console, escrito em .NET 5");
            Console.WriteLine(" ");
            Console.WriteLine("Oual sua pergunta?");
            Console.WriteLine(" ");
            var prompt = Console.ReadLine();
            ChatGptRequest chatGptRequest = new(prompt);
            return chatGptRequest;
        }

        private static StringContent CreateJsonContent(ChatGptRequest chatGptRequest, JsonSerializerOptions jsonSerializerOptions)
        {
            string json = JsonSerializer.Serialize(chatGptRequest, jsonSerializerOptions);
            StringContent jsonContent = new(json, Encoding.UTF8, "application/json");
            return jsonContent;
        }

        private static async Task<string> YourResponseAsync(StringContent jsonContent, JsonSerializerOptions jsonSerializerOptions)
        {
            var openaiUrl = "https://api.openai.com/v1/completions";
            var openaiApiKey = "YOUR_APP_KEY";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", openaiApiKey);
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(openaiUrl, jsonContent);
            string responseContent = await httpResponseMessage.Content.ReadAsStringAsync();

            if (responseContent != null)
            {
                ChatGptResponse chatGptResponse = JsonSerializer.Deserialize<ChatGptResponse>(responseContent, jsonSerializerOptions);
                return chatGptResponse.Choices != null ? chatGptResponse.Choices[0].Text : "Sem resposta";
            }
            else 
            {
                return "Sem resposta!";
            }
        }
    }
}