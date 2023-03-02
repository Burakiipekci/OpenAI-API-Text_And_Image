using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.ResponseModels.ImageResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAPI_Example.Services
{
    public class OpenAIImageService : BackgroundService
    {
        IOpenAIService _openAIService;

        public OpenAIImageService(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                Console.WriteLine("İstediğin resim nasıl bir şey! : ");
                ImageCreateResponse response = await _openAIService.Image.CreateImage(new OpenAI.GPT3.ObjectModels.RequestModels.ImageCreateRequest()
                {
                    Prompt = Console.ReadLine(),
                    N = 2,
                    Size = StaticValues.ImageStatics.Size.Size256,
                    ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url,
                    User = "test"


                });
                Console.WriteLine(string.Join("\n", response.Results.Select(r => r.Url)));
            }
        }
    }
}
