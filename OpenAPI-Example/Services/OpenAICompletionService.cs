using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAPI_Example.Services
{
    public class OpenAICompletionService : BackgroundService
    {
        readonly IOpenAIService _openAIService;

        public OpenAICompletionService(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                Console.Write("Sorabilirsin :");
                
           CompletionCreateResponse response= await _openAIService.Completions.CreateCompletion(
               new OpenAI.GPT3.ObjectModels.RequestModels.CompletionCreateRequest()
                {

                    Prompt = Console.ReadLine(),
                    MaxTokens = 500


                }, Models.TextDavinciV3) ;
                Console.WriteLine(response.Choices[0].Text);
            }
        }
    }
}
