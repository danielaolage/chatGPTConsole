using Newtonsoft.Json;

namespace Models
{
    class ChatGptUsage
    {
        [JsonProperty("promptTokens")]
        public int PromptTokens { get; set; }

        [JsonProperty("completionTokens")]
        public int CompletionTokens { get; set; }

        [JsonProperty("totalTokens")]
        public int TotalTokens { get; set; }
    }
}
