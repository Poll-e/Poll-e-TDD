using System.Text.Json.Serialization;

namespace PollE.Controllers.DTOs
{
    public class PollCreate
    {
        [JsonPropertyName("title")] public string Title { get; set; }

        [JsonPropertyName("category")] public string Category { get; set; }
    }
}