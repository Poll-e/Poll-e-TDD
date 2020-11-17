﻿using System.Text.Json.Serialization;

namespace PollE.Controllers.DTOs
{
    public class Poll
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("category")]
        public string Category { get; set; }
        
        [JsonPropertyName("code")]
        public string Code { get; set; }
    }
}