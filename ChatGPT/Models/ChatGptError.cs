using Newtonsoft.Json;

namespace Models
{
    class ChatGptError
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("Param")]
        public object LogParamprobs { get; set; }

        [JsonProperty("code")]
        public object code { get; set; }
    }
}
