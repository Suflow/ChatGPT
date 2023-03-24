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
    public class GPT3_CompletionUsage
    {
        [JsonPropertyName("prompt_tokens")]
        public long PromptTokens { get; set; }

        [JsonPropertyName("completion_tokens")]
        public long CompletionTokens { get; set; }

        [JsonPropertyName("total_tokens")]
        public long TotalTokens { get; set; } 
    }
}