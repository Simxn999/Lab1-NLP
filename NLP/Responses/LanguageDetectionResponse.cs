using Newtonsoft.Json;

namespace NLPBot.Responses;

public class LanguageDetectionResponse
{
    [JsonProperty("language")]
    public string Language { get; set; } = default!;

    [JsonProperty("score")]
    public double Score { get; set; }

    [JsonProperty("isTranslationSupported")]
    public bool IsTranslationSupported { get; set; }

    [JsonProperty("isTransliterationSupported")]
    public bool IsTransliterationSupported { get; set; }
}