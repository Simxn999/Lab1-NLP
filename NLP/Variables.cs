using Microsoft.Extensions.Configuration;

namespace NLPBot;

public class Variables
{
    public static readonly Variables Instance = new();
    public readonly string CognitiveServiceEndpoint;
    public readonly string CognitiveServiceKey;
    public readonly string CognitiveServiceRegion;
    public readonly string LanguageServiceEndpoint;
    public readonly string LanguageServiceKey;
    public readonly string TranslatorEndpoint;

    Variables()
    {
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
        var configuration = builder.Build();

        CognitiveServiceEndpoint = configuration["CognitiveServiceEndpoint"];
        CognitiveServiceKey = configuration["CognitiveServiceKey"];
        CognitiveServiceRegion = configuration["CognitiveServiceRegion"];
        TranslatorEndpoint = configuration["TranslatorEndpoint"];
        LanguageServiceKey = configuration["LanguageServiceKey"];
        LanguageServiceEndpoint = configuration["LanguageServiceEndpoint"];
    }
}