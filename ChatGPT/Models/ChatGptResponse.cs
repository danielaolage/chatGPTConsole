using Newtonsoft.Json;
using System.Collections.Generic;

namespace Models
{
    class ChatGptResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("choices")]
        public List<ChatGptChoice> Choices { get; set; }

        [JsonProperty("usage")]
        public ChatGptUsage Usage { get; set; }

        [JsonProperty("error")]
        public ChatGptError? Error { get; set; }
    }
}
