//////////////////////////////////////////////////////////////////////////////////////////////////
//
//    Author: Ajit Dhungana
//    Copyright (C)
//
//////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Suflow.Automation;
using System.Linq;

namespace Suflow.Automation
{
    public class GPT3Service_Test
    {  
        public string Run()
        {
            var result = new StringBuilder();
            var gpt3ApiKey = ConfigService.GetConfigValue("appSettings", "GPT3.apiKey");
            var service = new GPT3Service(gpt3ApiKey);
            return service.GPT3_Completion("Who was president of America in 2000?");
        }
    }
}