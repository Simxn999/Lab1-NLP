using Newtonsoft.Json;

namespace NLPBot.Responses;

[Serializable]
public class TranslationResponse
{
    [JsonProperty("detectedLanguage")]
    public DetectedLanguage DetectedLanguage { get; set; } = default!;

    [JsonProperty("translations")]
    public List<Translation> Result { get; set; } = default!;
}

public class DetectedLanguage
{
    [JsonProperty("language")]
    public string Language { get; set; } = default!;

    [JsonProperty("score")]
    public decimal Score { get; set; }
}

public class Translation
{
    [JsonProperty("text")]
    public string Text { get; set; } = default!;

    [JsonProperty("to")]
    public string Language { get; set; } = default!;
}