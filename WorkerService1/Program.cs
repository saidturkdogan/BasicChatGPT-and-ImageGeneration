using OpenAI.API.Example.Services;
using OpenAI.GPT3.Extensions;
using OpenAI.API.Example;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddOpenAIService(settings => settings.ApiKey = "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");
        //services.AddHostedService<OpenAICompletionService>();
        services.AddHostedService<OpenIAIImageService>();
    })
    .Build();

host.Run();
