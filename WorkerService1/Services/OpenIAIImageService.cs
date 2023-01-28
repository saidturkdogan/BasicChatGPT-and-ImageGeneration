using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels.ImageResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI.API.Example.Services
{
    public class OpenIAIImageService : BackgroundService
    {
        readonly IOpenAIService _openAIService;

        public OpenIAIImageService(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                Console.Write("::");
                ImageCreateResponse result = await _openAIService.Image.CreateImage(new ImageCreateRequest()
                {
                    Prompt = Console.ReadLine(),
                    N = 2,
                    Size = StaticValues.ImageStatics.Size.Size256,
                    ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url,
                    User = "test"
                });
                    Console.WriteLine(string.Join("\n", result.Results.Select(r => r.Url)));
            }
        }
    }
}