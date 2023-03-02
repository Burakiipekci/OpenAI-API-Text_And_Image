using OpenAI.GPT3.Extensions;
using OpenAPI_Example;
using OpenAPI_Example.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddOpenAIService(settings => settings.ApiKey = "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");
        services.AddHostedService<OpenAIImageService>();
        services.AddHostedService<OpenAICompletionService>();
    })
    .Build();

host.Run();
