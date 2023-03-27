using System.Text.Json.Serialization;

namespace Models
{
    class ChatGptRequest
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        [JsonPropertyName("temperature")]
        public double Temperature { get; set; }

        [JsonPropertyName("max_tokens")]
        public int Max_tokens { get; set; }

        [JsonPropertyName("top_p")]
        public int Top_p { get; set; }

        [JsonPropertyName("frequency_penalty")]
        public int Frequency_penalty { get; set; }

        [JsonPropertyName("presence_penalty")]
        public int Presence_penalty { get; set; }

        public ChatGptRequest(string prompt)
        {
            this.Model = "text-davinci-003";
            this.Prompt = prompt;
            this.Temperature = 0f;
            this.Max_tokens = 150;
            this.Top_p = 1;
            this.Frequency_penalty = 0;
            this.Presence_penalty = 0;
        }
    }
}
