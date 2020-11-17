using System.Text.Json.Serialization;

namespace PollE.Controllers.DTOs
{
    public class PollCreated
    {
        [JsonPropertyName("code")] public string Code { get; set; }
    }
}