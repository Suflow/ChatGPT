//////////////////////////////////////////////////////////////////////////////////////////////////
//
//    Author: Ajit Dhungana
//    Copyright (C)
//
//////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Suflow.Automation
{
    public class GPT3_CompletionResult
    {
        /// <summary>
        /// The identifier of the result, which may be used during troubleshooting
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("object")]
        public string Object { get; set; }

        /// <summary>
        /// The time when the result was generated in unix epoch format
        /// </summary>
        [JsonPropertyName("created")]
        public long CreatedUnixTime { get; set; }

        /// The time when the result was generated
        // [JsonIgnore]
        // public DateTime Created => DateTimeOffset.FromUnixTimeSeconds(CreatedUnixTime).DateTime;
         
        [JsonPropertyName("model")]
        public string Model { get; set; }

        /// <summary>
        /// The completions returned by the API.  Depending on your request, there may be 1 or many choices.
        /// </summary>
        [JsonPropertyName("choices")]
        public GPT3_CompletionChoice[] Choices { get; set; }

        [JsonPropertyName("usage")]
        public GPT3_CompletionUsage Usage {get;set;}

        /// <summary>
        /// Gets the text of the first completion, representing the main result
        /// </summary>
        public override string ToString()
        {
            return Choices != null && Choices.Any()
                ? Choices[0].ToString()
                : $"CompletionResult {Id} has no valid output";
        }
    }
}
