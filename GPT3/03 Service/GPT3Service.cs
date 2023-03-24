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

//https://github.com/RageAgainstThePixel/OpenAI-DotNet
//https://beta.openai.com/docs/guides/completion/introduction
namespace Suflow.Automation
{
    public class GPT3Service
    {
        string _apiKey {get;set;} 

        public GPT3Service(string apiKey)
        {           
            _apiKey = apiKey;
        }

        public Dictionary<string, string> GetApiHeaders()
        {
            var headers = new Dictionary<string, string>();
            headers.Add("Authorization", "Bearer " + _apiKey);
            return headers;
        }

        public async Task<string> GPT3_Completion_Async(string prompt)
        {
            string url = "https://api.openai.com/v1/completions";
            var json = new {
                model = "text-davinci-003",
                prompt = prompt,
                temperature = 0.7,
                max_tokens = 2048,
                top_p = 1,
                frequency_penalty = 0,
                presence_penalty = 0
            };
            var data = JsonService.Stringify(json);
            Log4NetService.Info(data);
            return await HttpClientService.PostJsonAsync(url, data, true, GetApiHeaders());
        }  

        public string GPT3_Completion(string prompt)
        {
            var jsonAsync = GPT3_Completion_Async(prompt);
            jsonAsync.Wait();
            var strResult = jsonAsync.Result;
            // var formatedResult = JsonService.Format(strResult);
            // Log4NetService.Info(formatedResult);
            var result = JsonService.Deserialize<GPT3_CompletionResult>(strResult);
            //var deserializeResult = JsonService.Stringify(result);
            return result.Choices[0].Text; 
        }
    }
}